using Conference_Management_System.Data;
using Conference_Management_System.Enums;
using Conference_Management_System.Models;
using Conference_Management_System.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Conference_Management_System.Areas.Admin.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events
                .Include(e => e.Location)
                .Include(e => e.Organizer)
                .Where(e => !e.IsDeleted)
                .ToListAsync();

            var eventViewModels = new List<EventVM>();
            foreach (var @event in events)
            {
                var acceptedInvitationsCount = await _context.Invitations
                    .CountAsync(i => i.EventId == @event.Id && i.Status == InvitationStatusEnum.Accepted); // Enum istifadəsi

                var checkedInParticipantsCount = await _context.Participations
                    .CountAsync(p => p.Invitation.EventId == @event.Id);

                var averageRating = await _context.Feedbacks
                    .Where(f => f.EventId == @event.Id)
                    .AverageAsync(f => (double?)f.Rating) ?? 0.0;

                eventViewModels.Add(new EventVM
                {
                    Id = @event.Id,
                    Title = @event.Title,
                    Description = @event.Description,
                    Date = @event.Date,
                    LocationName = @event.Location.Name,
                    EventType = @event.EventType, // Enum dəyəri
                    OrganizerFullName = @event.Organizer.FullName,
                    AcceptedInvitationsCount = acceptedInvitationsCount,
                    CheckedInParticipantsCount = checkedInParticipantsCount,
                    AverageRating = averageRating
                });
            }

            return View(eventViewModels);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(e => e.Location)
                .Include(e => e.Organizer)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
            if (@event is null)
            {
                return NotFound();
            }

            var acceptedInvitationsCount = await _context.Invitations
                .CountAsync(i => i.EventId == @event.Id && i.Status == InvitationStatusEnum.Accepted);

            var checkedInParticipantsCount = await _context.Participations
                .CountAsync(p => p.Invitation.EventId == @event.Id);

            var averageRating = await _context.Feedbacks
                .Where(f => f.EventId == @event.Id)
                .AverageAsync(f => (double?)f.Rating) ?? 0.0;


            var viewModel = new EventVM
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Date = @event.Date,
                LocationName = @event.Location.Name,
                EventType = @event.EventType, // Enum dəyəri
                OrganizerFullName = @event.Organizer.FullName,
                AcceptedInvitationsCount = acceptedInvitationsCount,
                CheckedInParticipantsCount = checkedInParticipantsCount,
                AverageRating = averageRating
            };

            return View(viewModel);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewBag.Locations = new SelectList(_context.Locations.Where(l => !l.IsDeleted), "Id", "Name");
            ViewBag.Organizers = new SelectList(_context.Organizers.Where(o => !o.IsDeleted), "Id", "FullName");
            // EventType üçün SelectList yaratmaq üçün Enum.GetValues istifadə edirik
            ViewBag.EventTypes = Enum.GetValues(typeof(EventTypeEnum))
                                   .Cast<EventTypeEnum>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = e.ToString()
                                   }).ToList();
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var @event = new Event
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    LocationId = model.LocationId,
                    EventType = model.EventType, // Enum dəyərini birbaşa istifadə edin
                    OrganizerId = model.OrganizerId,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };
                _context.Add(@event);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Tədbir uğurla əlavə edildi.";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = new SelectList(_context.Locations.Where(l => !l.IsDeleted), "Id", "Name", model.LocationId);
            ViewBag.Organizers = new SelectList(_context.Organizers.Where(o => !o.IsDeleted), "Id", "FullName", model.OrganizerId);
            ViewBag.EventTypes = Enum.GetValues(typeof(EventTypeEnum))
                                   .Cast<EventTypeEnum>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = e.ToString(),
                                       Selected = e == model.EventType
                                   }).ToList();
            return View(model);
        }

        // Edit metodları da EventType-ı enum kimi qəbul etməlidir.
        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null || @event.IsDeleted)
            {
                return NotFound();
            }

            var model = new EventEditViewModel
            {
                Id = @event.Id,
                Title = @event.Title,
                Description = @event.Description,
                Date = @event.Date,
                LocationId = @event.LocationId,
                EventType = @event.EventType, // Enum dəyəri
                OrganizerId = @event.OrganizerId
            };

            ViewBag.Locations = new SelectList(_context.Locations.Where(l => !l.IsDeleted), "Id", "Name", model.LocationId);
            ViewBag.Organizers = new SelectList(_context.Organizers.Where(o => !o.IsDeleted), "Id", "FullName", model.OrganizerId);
            ViewBag.EventTypes = Enum.GetValues(typeof(EventTypeEnum))
                                   .Cast<EventTypeEnum>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = e.ToString(),
                                       Selected = e == model.EventType
                                   }).ToList();
            return View(model);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var @event = await _context.Events.FindAsync(id);
                    if (@event == null || @event.IsDeleted)
                    {
                        return NotFound();
                    }

                    @event.Title = model.Title;
                    @event.Description = model.Description;
                    @event.Date = model.Date;
                    @event.LocationId = model.LocationId;
                    @event.EventType = model.EventType; // Enum dəyəri
                    @event.OrganizerId = model.OrganizerId;
                    @event.UpdatedAt = DateTime.Now;

                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Tədbir uğurla yeniləndi.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = new SelectList(_context.Locations.Where(l => !l.IsDeleted), "Id", "Name", model.LocationId);
            ViewBag.Organizers = new SelectList(_context.Organizers.Where(o => !o.IsDeleted), "Id", "FullName", model.OrganizerId);
            ViewBag.EventTypes = Enum.GetValues(typeof(EventTypeEnum))
                                   .Cast<EventTypeEnum>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = e.ToString(),
                                       Text = e.ToString(),
                                       Selected = e == model.EventType
                                   }).ToList();
            return View(model);
        }

        // Delete metodları eyni qalır
        // ...
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id && !e.IsDeleted);
        }
    }
}
