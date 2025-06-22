using Conference_Management_System.Data;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;

namespace Conference_Management_System.Repositories.Implementations
{
    public class ParticipationRepository : GenericRepository<Participation>, IParticipationRepository
    {
        public ParticipationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
