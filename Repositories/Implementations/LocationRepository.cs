using Conference_Management_System.Data;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;

namespace Conference_Management_System.Repositories.Implementations
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
