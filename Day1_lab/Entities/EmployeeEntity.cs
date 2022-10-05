using Day1_lab.ENUMs;

namespace Day1_lab.Entity
{
    public class EmployeeEntity : BaseClass
    {
        public EmployeeEntity(string name,
                              string lastName,
                              SexEnum gender,
                              string cargo,
                              int? cHijos = default)
        {
            Name = name;
            LastName = lastName;
            Gender = gender;
            Cargo = cargo;
            CHijos = cHijos ?? 0;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public SexEnum Gender { get; set; }
        public string FullName => $"{Name} {LastName}";
        public string Cargo { get; set; }
        public int? CHijos { get; set; }
    }
}
