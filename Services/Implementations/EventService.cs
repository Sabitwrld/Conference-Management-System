using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Event;

namespace Conference_Management_System.Services.Implementations
{
    public class EventService : GenericService<EventVM, Event>, IEventService
    {
        public EventService(IGenericRepository<Event> repository, IMapper mapper) : base(repository, mapper)
        { }

    }
}
