using AutoMapper;
using Day6_HW_Agenda.Domain.Entities;
using Day6_HW_Agenda.Domain.IRepositories;
using Day6_HW_Agenda.DTOs.ContactsDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day6_HW_Agenda.Controllers
{
    public class ContactsController : BaseController
    {
        private readonly IGenericRepository<Contacts> _contactsService;
        private readonly IMapper _mapper;
        public ContactsController(IGenericRepository<Contacts> contactsService, IMapper mapper)
        {
            _mapper = mapper;
            _contactsService = contactsService;
        }

        /*[Authorize]*/
        [HttpPost("CreateContacts")]
        public async Task<ActionResult<ResponseContactsDto>> CreateContacts([FromForm] CreateContactsDto createContacts)
        {
            var contact = _mapper.Map<Contacts>(createContacts);

            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            contact.EmailCreator = email;

            var result = await _contactsService.CreateAsync(contact);

            if (result == 0) return BadRequest("Hubo un error creando contacto");

            var responseContact = _mapper.Map<ResponseContactsDto>(contact);

            return responseContact;
        }

        /*[Authorize]*/
        [HttpGet("GetContacts")]
        public async Task<ActionResult<List<ResponseContactsDto>>> GetContacts()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var contacts = await _contactsService.GetAsync();

            contacts.Where(x => x.EmailCreator == email);

            if (contacts == null) return BadRequest();

            var responseContacts = _mapper.Map<List<ResponseContactsDto>>(contacts);

            return responseContacts;
        }

        /*[Authorize]*/
        [HttpGet("GetContact/{id}")]
        public async Task<ActionResult<ResponseContactsDto>> GetContact([FromForm] int id)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var contact = await _contactsService.GetAsync(id);

            if (contact == null) return BadRequest();

            if (contact.EmailCreator != email) return BadRequest();

            var responseContact = _mapper.Map<ResponseContactsDto>(contact);

            return responseContact;
        }

        /*[Authorize]*/
        [HttpPut("ModifyContact/{id}")]
        public async Task<ActionResult<ResponseContactsDto>> ModifyContact([FromForm] int id, ModifyContactsDto modifyContact)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var contact = _mapper.Map<Contacts>(modifyContact);

            contact.Id = id;

            if (contact.EmailCreator != email) return Unauthorized();

            var result = await _contactsService.ModifyAsync(contact);

            if (result == null) return BadRequest();

            var response = _mapper.Map<ResponseContactsDto>(result);

            return response;
        }

        /*[Authorize]*/
        [HttpDelete("DeleteContact/{id}")]
        public async Task<ActionResult<string>> DeleteContact([FromForm] int id)
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            var contact = await _contactsService.GetAsync(id);

            if (contact.EmailCreator != email) return Unauthorized();

            var result = await _contactsService.Delete(contact);

            if (result == 1) return "Contacto eliminado";

            return "Error eliminando contacto";
        }
    }
}
