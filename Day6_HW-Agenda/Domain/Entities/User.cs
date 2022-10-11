using Microsoft.AspNetCore.Identity;

namespace Day6_HW_Agenda.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
