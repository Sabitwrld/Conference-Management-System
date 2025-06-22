using Conference_Management_System.Data;
using Conference_Management_System.Models;
using Conference_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Conference_Management_System.Repositories.Implementations
{
    public class PersonRepository<TEntity> : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
       
    }
}
