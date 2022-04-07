using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.Post;
using AlumniNetworkAPI.Models.DTO.Event;
using AutoMapper;
namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;
        public EventsController(AlumniNetworkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEvent(int id, EventUpdateDTO @event)
        {

            if (id != @event.Event_Id)
            {
                return BadRequest();
            }

            var oldEvent = await _context.Events.AsNoTracking().FirstOrDefaultAsync(m => m.Event_Id == id);

            var domainEvent = _mapper.Map<Event>(@event);

            domainEvent.CreatedByUserId = oldEvent.CreatedByUserId;
            domainEvent.LastUpdated = DateTime.Now;

            _context.Entry(domainEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventReadDTO>> PostEvent([FromBody] EventCreateDTO @event)
        {
            var domainEvent = _mapper.Map<Event>(@event);

            _context.Events.Add(domainEvent);

            await _context.SaveChangesAsync();

            var EventToSend = _mapper.Map<EventReadDTO>(domainEvent);

            return CreatedAtAction("GetEvent", new { id = domainEvent.Event_Id }, EventToSend);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Event_Id == id);
        }
    }
}
