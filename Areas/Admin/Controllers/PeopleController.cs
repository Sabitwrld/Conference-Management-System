using Conference_Management_System.Data;
using Conference_Management_System.Enums;
using Conference_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Conference_Management_System.Areas.Admin.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PeopleController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public class CreateProfileViewModel
        {
            [Required, MaxLength(100)]
            [Display(Name = "Ad")]
            public string Name { get; set; }
            [Required, MaxLength(100)]
            [Display(Name = "Soyad")]
            public string Surname { get; set; }
            [MaxLength(20)]
            [Display(Name = "Telefon Nömrəsi")]
            public string Phone { get; set; }
            [Required]
            [Display(Name = "Rol")]
            public PersonRoleEnum Role { get; set; }
        }

        // GET: People/CreateProfile
        public async Task<IActionResult> CreateProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.PersonId.HasValue)
            {
                // Artıq bir profili var, bu səhifəyə daxil olmasını istəmirik
                TempData["InfoMessage"] = "Sizin artıq profiliniz var.";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        // POST: People/CreateProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProfile(CreateProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user.PersonId.HasValue)
                {
                    TempData["InfoMessage"] = "Sizin artıq profiliniz var.";
                    return RedirectToAction("Index", "Home");
                }

                var person = new Person
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = user.Email, // Email Identity-dən götürülür
                    Phone = model.Phone,
                    Role = model.Role,
                    CreatedAt = DateTime.Now
                };

                _context.Add(person);
                await _context.SaveChangesAsync();

                // PersonId-ni ApplicationUser-ə bağlayın
                user.PersonId = person.Id;
                await _userManager.UpdateAsync(user);

                TempData["SuccessMessage"] = "Profiliniz uğurla yaradıldı!";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
