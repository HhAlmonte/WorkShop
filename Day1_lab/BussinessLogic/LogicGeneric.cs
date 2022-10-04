using Day1_lab.Entity;
using Day1_lab.Interface;

namespace Day1_lab.BussinessLogic
{
    public class LogicGeneric<T> : IGenericInterface<T> where T : BaseClass
    {
        public static List<T> values = new List<T>();
        public bool Create(T value)
        {
            values.Add(value);
            return true;
        }

        public bool Delete(int valueId)
        {
            int index = valueId;
            bool employeesExist = false;

            foreach (T item in values)
            {
                if(item.Id != valueId)
                {
                    employeesExist = false;
                    Console.WriteLine("El empleado ingresado no existe. Intentelo despues");
                }
                if (employeesExist)
                {
                    values.RemoveAt(index);
                    return true;
                }
            }

            return false;
        }

        public bool Modify(T value)
        {
            Console.WriteLine("En proceso. Lo sentimos.");
            return false;
        }

        public List<T> Read()
        {
            return values;
        }
    }
}
