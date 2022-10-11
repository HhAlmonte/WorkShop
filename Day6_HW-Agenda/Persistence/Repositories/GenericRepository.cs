using Day6_HW_Agenda.Domain.Entities;
using Day6_HW_Agenda.Domain.IRepositories;
using Day6_HW_Agenda.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Day6_HW_Agenda.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseClass
    {
        private readonly ContactsDbContext _context;

        public GenericRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity value)
        {
            await _context.Set<TEntity>().AddAsync(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public bool Delete(TEntity value)
        {
            var entity = GetAsync(value.Id);
            
            if (entity == null) return false;
            
            value.Deleted = true;

            _context.SaveChanges();
            
            return true;
        }

        public async Task<List<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>()
                .Where(x => x.Deleted == false)
                .ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _context.Set<TEntity>()
                .Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> ModifyAsync(TEntity value)
        {
            _context.Set<TEntity>().Update(value);
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
