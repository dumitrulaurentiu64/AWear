using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWear_API.Data;
using AWear_API.Models;
using Microsoft.AspNetCore.Authorization;
using AWear_API.Dtos;
using AutoMapper;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class WarningsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public WarningsController(IMapper mapper, DataContext context, IClinicRepository clinicRepository)
        {
            _context = context;
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }

        // GET: api/Warnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warning>>> GetWarnings()
        {
            return await _context.Warnings.ToListAsync();
        }

        // GET: api/Warnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warning>> GetWarning(Guid id)
        {
            var warning = await _context.Warnings.FindAsync(id);

            if (warning == null)
            {
                return NotFound();
            }

            return warning;
        }

        [HttpGet("ofPacient")]
        public async Task<IActionResult> GetWarningsOfPacient([FromQuery]Guid PacientId)
        {
            var warnings = await _clinicRepository.GetWarningsOfPacient(PacientId);

            if (warnings == null)
            {
                return NotFound();
            }

            return Ok(warnings);
        }

        // PUT: api/Warnings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarning(Guid id, Warning warning)
        {
            if (id != warning.Id)
            {
                return BadRequest();
            }

            _context.Entry(warning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarningExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Warnings
        /*[HttpPost]
        public async Task<ActionResult<Warning>> PostWarning(Warning warning)
        {
            _context.Warnings.Add(warning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarning", new { id = warning.Id }, warning);
        }*/

        [HttpPost]
        public async Task<IActionResult> PostWarningOfPacient([FromQuery]Guid PacientId, [FromBody]WarningToAdd warData)
        {
            var pacient = await _clinicRepository.GetPacient(PacientId, true);
            
            if (pacient == null )
                return BadRequest("Pacient not found");


            var warning = _mapper.Map<Warning>(warData);

            warning.IssuedToPacient = pacient;
            warning.PacientId = pacient.Id;

            _context.Warnings.Add(warning);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarning", new { id = warning.Id }, warning);
        }

        // DELETE: api/Warnings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Warning>> DeleteWarning(Guid id)
        {
            var warning = await _context.Warnings.FindAsync(id);
            if (warning == null)
            {
                return NotFound();
            }

            _context.Warnings.Remove(warning);
            await _context.SaveChangesAsync();

            return warning;
        }

        private bool WarningExists(Guid id)
        {
            return _context.Warnings.Any(e => e.Id == id);
        }
    }
}
