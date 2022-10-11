using Day6_HW_Agenda.Domain.Entities;

namespace Day6_HW_Agenda.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseClass
    {
        Task<TEntity> CreateAsync(TEntity value);
        bool Delete(TEntity value);
        Task<TEntity> ModifyAsync(TEntity value);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
    }
}
