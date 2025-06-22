using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Invitation;

namespace Conference_Management_System.Services.Implementations
{
    public class InvitationService : GenericService<InvitationVM, Invitation>, IinvitationService
    {
        public InvitationService(IGenericRepository<Invitation> repository, IMapper mapper) : base(repository, mapper)
        { }

    }
}
