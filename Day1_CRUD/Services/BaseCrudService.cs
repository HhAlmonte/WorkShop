using Day1_CRUD.Entities;
using Day1_CRUD.Interface;

namespace Day1_CRUD.Services
{
    public class BaseCrudService<TEntity> : IBaseCrudService<TEntity> where TEntity : Base
    {
        protected List<TEntity> _database;
        private int IdCounter;
        public BaseCrudService()
        {
            _database = new List<TEntity>();
            IdCounter = 1;
        }

        public List<TEntity> Get()
        {
            var result = _database.ToList().Where(x => !x.Deleted);
            if (result == null)
            {
                throw new Exception("No hay datos");
            }
            return result.ToList();

        }

        public IQueryable<TEntity> Query()
        {
            return _database.AsQueryable().Where(x => !x.Deleted);
        }

        public TEntity GetById(int id)
        {
            var result = Query().FirstOrDefault(entity => entity.Id == id);
            if (result == null)
            {
                throw new Exception("No hay datos");
            }
            return result;
        }

        public TEntity Create(TEntity entity)
        {
            entity.Id = IdCounter;
            _database.Add(entity);
            IdCounter++;
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Delete(entity.Id);
            return Create(entity);
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            entity.Deleted = true;
            return true;
        }
    }
}