using Day1_CRUD.ENUMs;

namespace Day1_CRUD.Entities
{
    public class Person : Base
    {
        public string Name { get; set; }
        public Sex Gender { get; set; }
        public DateTimeOffset BithDate { get; set; }
    }
}
