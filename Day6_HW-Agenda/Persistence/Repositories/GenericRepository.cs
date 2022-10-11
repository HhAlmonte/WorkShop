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

        public async Task<int> CreateAsync(TEntity value)
        {
            _context.Set<TEntity>().Add(value);
            return await _context.SaveChangesAsync();
        }
        
        public async Task<int> Delete(TEntity value)
        {
            var entity = await GetAsync(value.Id);
            
            entity.Deleted = true;

            return _context.SaveChanges();
        }
        public async Task<int> ModifyAsync(TEntity value)
        {
            _context.Set<TEntity>().Update(value);
            return await _context.SaveChangesAsync();
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

    }
}
