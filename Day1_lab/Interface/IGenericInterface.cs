using Day1_lab.Entity;

namespace Day1_lab.Interface
{
    public interface IGenericInterface<T> where T : BaseClass 
    {
        bool Create(T value);
        bool Delete(int valueId);
        bool Modify(T value);
        List<T> Read();
    }
}
