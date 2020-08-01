using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using AWear_API.Data;
using AWear_API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientsController : ControllerBase
    {
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public PacientsController(IClinicRepository clinicRepository, IMapper mapper)
        {
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = "GetPacient")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            //var isCurrentUser = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value) == id;

            var user = await _clinicRepository.GetPacient(id, true);

            var userToReturn = _mapper.Map<PacientToDetailed>(user);

            return Ok(userToReturn);
        }

        [HttpGet("ofMedic")]
        public async Task<IActionResult> GetPacientsOfMedic([FromQuery] Guid MedicId)
        {
            var pacients = await _clinicRepository.GetPacientsForMedic(MedicId);

            var pm = _mapper.Map<IEnumerable<PacientToDetailed>>(pacients);

            return Ok(pm);
        }
    }
}