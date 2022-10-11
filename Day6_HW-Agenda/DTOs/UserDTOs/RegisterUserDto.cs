using System.ComponentModel.DataAnnotations;

namespace Day6_HW_Agenda.DTOs.UserDTOs
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
