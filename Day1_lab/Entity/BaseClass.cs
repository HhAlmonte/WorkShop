namespace Day1_lab.Entity
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public bool Deleted { get; set; }
    }
}
