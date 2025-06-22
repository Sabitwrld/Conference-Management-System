using AutoMapper;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Conference_Management_System.Services.Interfaces;
using Conference_Management_System.ViewModels.Person;

namespace Conference_Management_System.Services.Implementations
{
    public class PersonService : GenericService<PersonVM, Person>, IPersonService
    {
        public PersonService(IGenericRepository<Person> repository, IMapper mapper) : base(repository, mapper)
        { }
    }
}
