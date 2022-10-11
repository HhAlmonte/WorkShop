namespace Day6_HW_Agenda.Domain.Entities
{
    public class BaseClass
    {
        public int Id { get; set; }
        public DateTime Created { get; } = DateTime.Now;
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
