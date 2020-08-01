using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AWear_API.Data;
using AWear_API.Dtos;
using AWear_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicsController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public MedicsController(IClinicRepository clinicRepository, IMapper mapper)
        {
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMedics()
        {
            var medics =  await _clinicRepository.GetMedics();

            if (medics == null)
                return BadRequest("Error");

            return Ok(medics);
        }

        [HttpGet("{id}", Name = "GetMedic")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            //var isCurrentUser = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == id;

            var user = await _clinicRepository.GetMedic(id, false);

            var pacients = user.Pacients;

            var userToReturn = _mapper.Map<MedicForDetaildDto>(user);
            userToReturn.Pacients = pacients;

            return Ok(userToReturn);
        }
    }
}