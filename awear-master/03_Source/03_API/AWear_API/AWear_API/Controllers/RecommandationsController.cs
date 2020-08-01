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
using AutoMapper;
using AWear_API.Dtos;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RecommandationsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public RecommandationsController(IMapper mapper, DataContext context, IClinicRepository clinicRepository)
        {
            _context = context;
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }

        // GET: api/Recommandations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recommandation>>> GetRecommandations()
        {
            return await _context.Recommandations.ToListAsync();
        }

        // GET: api/Recommandations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recommandation>> GetRecommandation(Guid id)
        {
            var recommandation = await _context.Recommandations.FindAsync(id);

            if (recommandation == null)
            {
                return NotFound();
            }

            return recommandation;
        }

        [HttpGet("ofPacientByMedic")]
        public async Task<IActionResult> GetRecommandationsOfPacientByMedic([FromQuery] Guid PacientId, [FromQuery] Guid MedicId)
        {
            var recommandation = await _clinicRepository.GetRecommandationsOfPacientByMedic(PacientId, MedicId);

            if (recommandation == null)
            {
                return NotFound();
            }

            return Ok(recommandation);
        }

        // PUT: api/Recommandations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommandation(Guid id, Recommandation recommandation)
        {
            if (id != recommandation.Id)
            {
                return BadRequest();
            }

            _context.Entry(recommandation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommandationExists(id))
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

        // POST: api/Recommandations
       /* [HttpPost]
        public async Task<ActionResult<Recommandation>> PostRecommandation(Recommandation recommandation)
        {
            _context.Recommandations.Add(recommandation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecommandation", new { id = recommandation.Id }, recommandation);
        }*/

        [HttpPost]
        public async Task<IActionResult> PostRecommandationOfPacientByMedic([FromQuery]Guid PacientId, [FromQuery] Guid MedicId,[FromBody]RecommandationToAdd recData)
        {
            var pacient = await _clinicRepository.GetPacient(PacientId, true);
            var medic = await _clinicRepository.GetMedic(MedicId, true);
            if (pacient == null || medic == null)
                return BadRequest("Pacient/Medic not found");


            var rec = _mapper.Map<Recommandation>(recData);

            rec.IssuedToPacient = pacient;
            rec.IssuedByMedic = medic;
            rec.PacientId = PacientId;
            rec.MedicId = MedicId;

            _context.Recommandations.Add(rec);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecommandation", new { id = rec.Id }, rec);
        }

        // DELETE: api/Recommandations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recommandation>> DeleteRecommandation(Guid id)
        {
            var recommandation = await _context.Recommandations.FindAsync(id);
            if (recommandation == null)
            {
                return NotFound();
            }

            _context.Recommandations.Remove(recommandation);
            await _context.SaveChangesAsync();

            return recommandation;
        }

        private bool RecommandationExists(Guid id)
        {
            return _context.Recommandations.Any(e => e.Id == id);
        }
    }
}
