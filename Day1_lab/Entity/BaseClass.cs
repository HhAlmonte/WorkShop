namespace Day1_lab.Entity
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public DateTime Deleted { get; set; }
        public DateTime Modified { get; set; }
    }
}
