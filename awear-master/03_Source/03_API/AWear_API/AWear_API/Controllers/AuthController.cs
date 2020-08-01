using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AWear_API.Dtos;
using AWear_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using AWear_API.Data;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IClinicRepository _clinicRepository;

        public AuthController(IClinicRepository clinicRepository,IConfiguration config, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManger, IMapper mapper)
        {
            _userManager = userManger;
            _signInManager = signInManger;
            _mapper = mapper;
            _config = config;
            _clinicRepository = clinicRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserToLogin userForLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userForLoginDto.email);

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, userForLoginDto.password, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.NormalizedEmail == userForLoginDto.email.ToUpper());

                var userToReturn = _mapper.Map<ApplicationUser>(appUser);

                return Ok(new
                {
                    token = GenerateJwtToken(appUser).Result,
                    user = userToReturn
                });
            }

            return Unauthorized();
        }

        [HttpPost("register_medic")]
        public async Task<IActionResult> Register_Medic(MedicToRegister userForRegisterDto)
        {
            var userToCreate = _mapper.Map<Medic>(userForRegisterDto);

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);
            await _userManager.AddToRoleAsync(userToCreate, "Medic");

            var userToReturn = _mapper.Map<Medic>(userToCreate);

            if (result.Succeeded)
            {
                return CreatedAtRoute("GetMedic",
                    new { controller = "Medics", id = userToCreate.Id }, userToReturn);
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("register_pacient")]
        public async Task<IActionResult> Register_Pacient([FromQuery]Guid MedicId, [FromBody]PacientToRegisterDto userForRegisterDto)
        {
            var medic = await _clinicRepository.GetMedic(MedicId, false);
            if(medic == null)
            {
                return BadRequest("Medic doesn't exist");
            }
            var userToCreate = _mapper.Map<Pacient>(userForRegisterDto);
            userToCreate.Medic = medic;

            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);
            await _userManager.AddToRoleAsync(userToCreate, "Pacient");

            var userToReturn = _mapper.Map<PacientToDetailed>(userToCreate);

            if (result.Succeeded)
            {
                return CreatedAtRoute("GetPacient",
                    new { controller = "Pacients", id = userToCreate.Id }, userToReturn);
            }

            return BadRequest(result.Errors);
        }


        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}