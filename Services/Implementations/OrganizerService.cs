using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Organizer;

namespace Conference_Management_System.Services.Implementations
{
    public class OrganizerService : GenericService<OrganizerVM, Organizer>, IOrganizerService
    {
        public OrganizerService(IGenericRepository<Organizer> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
