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
using System.Web.Http.Cors;


namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]

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

        // GET: api/Groups/5
        [HttpPost("{EventId}/invite/group/{GroupId}")]
        public async Task<ActionResult<Event>> PostGroupEventInvite(int GroupId, int EventId)
        {

            EventGroupInvite eventGroupInvite = new EventGroupInvite();
            eventGroupInvite.GroupId = GroupId;
            eventGroupInvite.EventId = EventId;

            _context.EventGroupInvites.Add(eventGroupInvite);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Events/5
        [HttpDelete("{EventId}/invite/group/{GroupId}")]
        public async Task<IActionResult> DeleteEventGroupInvite(int EventId, int GroupId)
        {
            //var @event = await _context.EventGroupInvites.FindAsync(id);
            var @event = await _context.EventGroupInvites.AsNoTracking().FirstOrDefaultAsync(m => m.GroupId == GroupId && m.EventId == EventId);

            if (@event == null)
            {
                return NotFound();
            }

            _context.EventGroupInvites.Remove(@event);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Groups/5
        [HttpPost("{EventId}/invite/topic/{TopicId}")]
        public async Task<ActionResult<Event>> TopicEventInvite(int TopicId, int EventId)
        {

            EventTopicInvite eventTopicInvite = new EventTopicInvite();
            eventTopicInvite.TopicId = TopicId;
            eventTopicInvite.EventId = EventId;

            _context.EventTopicInvites.Add(eventTopicInvite);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Events/5
        [HttpDelete("{EventId}/invite/topic/{TopicId}")]
        public async Task<IActionResult> DeleteEventTopicInvite(int EventId, int TopicId)
        {
            var @event = await _context.EventTopicInvites.AsNoTracking().FirstOrDefaultAsync(m => m.TopicId == TopicId && m.EventId == EventId);

            if (@event == null)
            {
                return NotFound();
            }

            _context.EventTopicInvites.Remove(@event);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Groups/5
        [HttpPost("{EventId}/invite/user/{UserId}")]
        public async Task<ActionResult<Event>> EventUserInvite(int UserId, int EventId)
        {

            EventUserInvite eventUserInvite = new EventUserInvite();
            eventUserInvite.UserId = UserId;
            eventUserInvite.EventId = EventId;

            _context.EventUserInvites.Add(eventUserInvite);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Events/5
        [HttpDelete("{EventId}/invite/user/{UserId}")]
        public async Task<IActionResult> DeleteEventUserInvite(int EventId, int UserId)
        {
            var @event = await _context.EventUserInvites.AsNoTracking().FirstOrDefaultAsync(m => m.UserId == UserId && m.EventId == EventId);

            if (@event == null)
            {
                return NotFound();
            }

            _context.EventUserInvites.Remove(@event);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Groups/5
        [HttpPost("event/{EventId}/rsvp/{UserId}")]
        public async Task<ActionResult<Event>> RSVP(int UserId, int EventId)
        {
            if(RSVPExists(EventId, UserId))
            {
               return NoContent();
            }

            var rsvpCount = _context.RSVPs.Where(a => a.EventId == EventId).ToList().Count();
            rsvpCount++;

            RSVP rsvpDomain = new RSVP();
            rsvpDomain.UserId = UserId;
            rsvpDomain.EventId = EventId;
            rsvpDomain.Last_Updated = DateTime.Now;
            rsvpDomain.Guest_Count = rsvpCount;


            _context.RSVPs.Add(rsvpDomain);

            var allRSVPs = _context.RSVPs.Where(a => a.EventId == EventId).ToList();

            foreach (RSVP rsvp in allRSVPs)
            {
                rsvp.Guest_Count = rsvpCount;
                _context.Entry(rsvp).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
        private bool RSVPExists(int EventId, int UserId)
        {
            return _context.RSVPs.Any(e => e.EventId == EventId && e.UserId == UserId);
        }
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Event_Id == id);
        }
    }
}
