using Day1_lab.Entity;
using Day1_lab.Interface;

namespace Day1_lab.BussinessLogic
{
    public class LogicGeneric<TEntity> : IGenericInterface<TEntity> where TEntity : BaseClass
    {
        protected List<TEntity> values;
        private int IdCounter;
        
        public LogicGeneric()
        {
            values = new List<TEntity>();
            IdCounter = 1;
        }

        public List<TEntity> Get()
        {
            var result = values.ToList().Where(x => !x.Deleted);

            if (result == null)
            {
                throw new Exception("No hay datos para mostrar");
            }

            return result.ToList();
        }

        public TEntity Get(int id)
        {
            var result =  values.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new Exception("No hay datos para mostrar");
            }

            return result;
        }

        public TEntity Create(TEntity entity)
        {
            entity.Id = IdCounter;
            values.Add(entity);
            IdCounter++;
            return entity;
        }

        public bool Delete(int valueId)
        {
            var entity = Get(valueId);
            entity.Deleted = true;
            return true;
        }

        public TEntity Modify(TEntity entity)
        {
            Delete(entity.Id);
            return Create(entity);
        }
    }
}
