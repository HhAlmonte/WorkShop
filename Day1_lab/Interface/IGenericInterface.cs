using Day1_lab.Entity;

namespace Day1_lab.Interface
{
    public interface IGenericInterface<TEntity> where TEntity : BaseClass 
    {
        TEntity Create(TEntity value);
        bool Delete(int valueId);
        TEntity Modify(TEntity value);
        List<TEntity> Get();
        TEntity Get(int id);
    }
}
