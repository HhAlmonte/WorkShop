using Day1_CRUD.Entities;

namespace Day1_CRUD.Interface
{
    public interface IBaseCrudService<TEntity> where TEntity : Base
    {
        List<TEntity> Get();
        IQueryable<TEntity> Query();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(int id);
    }
}
