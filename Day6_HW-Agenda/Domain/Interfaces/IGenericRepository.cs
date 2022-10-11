using Day6_HW_Agenda.Domain.Entities;

namespace Day6_HW_Agenda.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseClass
    {
        Task<int> CreateAsync(TEntity value);
        Task<int> Delete(TEntity value);
        Task<int> ModifyAsync(TEntity value);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
    }
}
