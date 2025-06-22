using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Location;

namespace Conference_Management_System.Services.Implementations
{
    public class LocationService : GenericService<LocationVM, Location>, ILocationService
    {
        public LocationService(IGenericRepository<Location> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
