using AutoMapper;
using Day6_HW_Agenda.Domain.Entities;
using Day6_HW_Agenda.Domain.IRepositories;
using Day6_HW_Agenda.DTOs.ContactsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day6_HW_Agenda.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IGenericRepository<Contacts> _contactsService;
        private readonly IMapper _mapper;
        private readonly string _email;

        public ContactsController(IGenericRepository<Contacts> contactsService, IMapper mapper)
        {
            _mapper = mapper;
            _email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            _contactsService = contactsService;
        }

        [Authorize]
        [HttpPost("CreateContacts")]
        public async Task<ActionResult<ResponseContactsDto>> CreateContacts([FromForm]CreateContactsDto createContacts)
        {
            var contact = _mapper.Map<Contacts>(createContacts);
            contact.EmailCreator = _email;
            
            var result = await _contactsService.CreateAsync(contact);

            if (result == null) return BadRequest();

            var responseContact = _mapper.Map<ResponseContactsDto>(contact);

            return responseContact;
        }

        [Authorize]
        [HttpGet("GetContacts")]
        public async Task<ActionResult<List<ResponseContactsDto>>> GetContacts()
        {
            var contacts = await _contactsService.GetAsync();
            
            contacts.Where(x => x.EmailCreator == _email);

            if (contacts == null) return BadRequest();

            var responseContacts = _mapper.Map<List<ResponseContactsDto>>(contacts);

            return responseContacts;
        }

        [Authorize]
        [HttpPut("GetContact/{id}")]
        public async Task<ActionResult<ResponseContactsDto>> GetContact([FromForm] int id)
        {
            var contact = await _contactsService.GetAsync(id);

            if (contact == null) return BadRequest();

            if (contact.EmailCreator != _email) return BadRequest();

            var responseContact = _mapper.Map<ResponseContactsDto>(contact);

            return responseContact;
        }

        [Authorize]
        [HttpPut("ModifyContact/{id}")]
        public async Task<ActionResult<ResponseContactsDto>> ModifyContact([FromForm] int id, ModifyContactsDto modifyContact)
        {
            var contact = _mapper.Map<Contacts>(modifyContact);
            contact.Id = id;

            if (contact.EmailCreator != _email) return Unauthorized();

            var result = await _contactsService.ModifyAsync(contact);

            if (result == null) return BadRequest();

            var response = _mapper.Map<ResponseContactsDto>(result);

            return response;
        }

        [Authorize]
        [HttpDelete("DeleteContact/{id}")]
        public async Task<ActionResult<string>> DeleteContact([FromForm] int id)
        {
            var contact = await _contactsService.GetAsync(id);

            if (contact.EmailCreator != _email) return Unauthorized();

            var result =  _contactsService.Delete(contact);

            if (result) return "Contacto eliminado";

            return  "Error eliminando contacto";
        }
    }
}
