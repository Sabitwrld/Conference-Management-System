using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Invitation;
using Conference_Management_System.ViewModels.Participation;

namespace Conference_Management_System.Services.Implementations
{
    public class ParticipationService : GenericService<ParticipationVM, Participation>, IParticipationService
    {
        public ParticipationService(IGenericRepository<Participation> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
