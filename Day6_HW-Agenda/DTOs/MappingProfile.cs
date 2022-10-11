using AutoMapper;
using Day6_HW_Agenda.Domain.Entities;
using Day6_HW_Agenda.DTOs.ContactsDTOs;
using Day6_HW_Agenda.DTOs.UserDTOs;

namespace Day6_HW_Agenda.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User profile
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, ResponseUserDto>();

            // Contacts profile
            CreateMap<CreateContactsDto, Contacts>();
            CreateMap<ModifyContactsDto, Contacts>();
            CreateMap<Contacts, ResponseContactsDto>();
            
        }
    }
}
