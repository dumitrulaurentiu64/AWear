using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AWear_API.Data;
using AWear_API.Models;
using Microsoft.AspNetCore.SignalR;
using AWear_API.Hubs;
using Microsoft.AspNetCore.Authorization;
using AWear_API.Dtos;
using AutoMapper;

namespace AWear_API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHubContext<SensorDataHub, ISensorDataHub> _hubContext;
        private readonly IClinicRepository _clinicRepository;
        private readonly IMapper _mapper;

        public SensorDataController(IMapper mapper, DataContext context, IHubContext<SensorDataHub, ISensorDataHub> hubContext, IClinicRepository clinicRepository)
        {
            _context = context;
            _hubContext = hubContext;
            _clinicRepository = clinicRepository;
            _mapper = mapper;
        }

        // GET: api/SensorData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetSensorData()
        {
            return await _context.SensorData.ToListAsync();
        }

        // GET: api/SensorData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorData(Guid id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);

            if (sensorData == null)
            {
                return NotFound();
            }

            return sensorData;
        }

        [HttpGet("ofPacient")]
        public async Task<IActionResult> GetSensorDataOfPacient([FromQuery]Guid PacientId)
        {
            var sensorDatas = await _clinicRepository.GetSensorDataOfPacientAsync(PacientId);

            if (sensorDatas == null)
            {
                return NotFound();
            }

            return Ok(sensorDatas);
        }

        // PUT: api/SensorData/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensorData(Guid id, SensorData sensorData)
        {
            if (id != sensorData.Id)
            {
                return BadRequest();
            }

            _context.Entry(sensorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
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

        /*// POST: api/SensorData
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostSensorData(SensorData sensorData)
        {
            _context.SensorData.Add(sensorData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensorData", new { id = sensorData.Id }, sensorData);
        }*/

        [HttpPost]
        public async Task<IActionResult> PostSensorDataOfPacient([FromQuery]Guid PacientId,[FromBody]SensorDataToAddDto sensorData)
        {
            var pacient = await _clinicRepository.GetPacient(PacientId, true);
            if (pacient == null)
                return BadRequest("Pacient not found");

            
            var s = _mapper.Map<SensorData>(sensorData);
            s.SensorDataOfPacient = pacient;
            s.PacientId = PacientId;
            _context.SensorData.Add(s);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SensorDataUpdate(s.Id, s.TimeStamp, s.Temperature, s.Humidity, s.Pulse, s.EKGValue);

            return CreatedAtAction("GetSensorData", new { id = s.Id }, s);
        }

        // DELETE: api/SensorData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorData(Guid id)
        {
            var sensorData = await _context.SensorData.FindAsync(id);
            if (sensorData == null)
            {
                return NotFound();
            }

            _context.SensorData.Remove(sensorData);
            await _context.SaveChangesAsync();

            return Ok(sensorData);
        }

        private bool SensorDataExists(Guid id)
        {
            return _context.SensorData.Any(e => e.Id == id);
        }
    }
}
