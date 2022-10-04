namespace Day1_lab.Entity
{
    public class EmployeeEntity : BaseClass
    {
        public EmployeeEntity(string name,
                              string lastName,
                              string gender,
                              int? cHijos = default)
        {
            Name = name;
            LastName = lastName;
            Gender = gender;
            CHijos = cHijos ?? 0;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? CHijos { get; set; }
    }
}
