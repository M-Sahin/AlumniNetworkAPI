using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.Topic;
using AutoMapper;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;

        public TopicsController(AlumniNetworkDbContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetGroups()
        {
            return await _context.Topics.ToListAsync();
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Topic>> GetTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }


        // POST: api/Topic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TopicReadDTO>> PostTopic([FromBody] TopicCreateDTO topic)
        {
            var domainTopic = _mapper.Map<Topic>(topic);

            _context.Topics.Add(domainTopic);

            await _context.SaveChangesAsync();

            var TopicToSend = _mapper.Map<TopicReadDTO>(domainTopic);

            return CreatedAtAction("GetTopic", new { id = domainTopic.topic_id }, TopicToSend);
        }
    }
}