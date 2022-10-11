using Day6_HW_Agenda.Domain.Entities;

namespace Day6_HW_Agenda.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
