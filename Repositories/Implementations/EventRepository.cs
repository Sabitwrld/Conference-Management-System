using Conference_Management_System.Data;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;

namespace Conference_Management_System.Repositories.Implementations
{
    public class EventRepository<TEntity> : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }
    }
}
