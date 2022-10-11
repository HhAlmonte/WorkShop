using AutoMapper;
using Day6_HW_Agenda.Domain.Entities;
using Day6_HW_Agenda.Domain.Interfaces;
using Day6_HW_Agenda.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Day6_HW_Agenda.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              ITokenService tokenService,
                              IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseUserDto>> Register([FromForm]RegisterUserDto registerUser)
        {
            var user = _mapper.Map<User>(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded) return BadRequest("Error creando el usuario");

            var responseUser = _mapper.Map<ResponseUserDto>(user);
            
            responseUser.Token = _tokenService.CreateToken(user);

            return responseUser;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseUserDto>> Login([FromForm] LoginUserDto loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

            if (!result.Succeeded) return Unauthorized();

            var responseUser = _mapper.Map<ResponseUserDto>(user);
            
            responseUser.Token = _tokenService.CreateToken(user);

            return responseUser;
        }
    }
}
