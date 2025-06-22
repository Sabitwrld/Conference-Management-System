using Conference_Management_System.Data;
using Conference_Management_System.Models.Common;
using Conference_Management_System.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Conference_Management_System.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity is null)
            {
                return false;
            }
            entity.IsDeleted = true;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _dbSet.Where(e => !e.IsDeleted)
                       .AsNoTracking()
                       .ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id)
        {
            await _dbSet.FindAsync(id);
            var entity = await _dbSet.AsNoTracking()
                                     .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
