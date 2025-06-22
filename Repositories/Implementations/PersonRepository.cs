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
        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons
                                 .Where(b => !b.IsDeleted)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(b => b.Id == id && !b.IsDeleted);
        }
    }
}
