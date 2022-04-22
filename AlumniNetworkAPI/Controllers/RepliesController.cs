using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.Replies;
using AutoMapper;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepliesController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;

        public RepliesController(AlumniNetworkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Replies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reply>>> GetReplies()
        {
            return await _context.Replies.ToListAsync();
        }

        // GET: api/Replies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReplyReadDTO>> GetReplies(int id)
        {
            var reply = await _context.Replies.FirstOrDefaultAsync(m => m.Reply_Id == id);



            if (reply == null)
            {
                return NotFound();
            }

            var replyToSend = _mapper.Map<ReplyReadDTO>(reply);



            return replyToSend;
        }


        // patch: api/Post/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> RepliesUpdate(int id, ReplyUpdateDTO newReply)
        {
            var oldReply = await _context.Replies.AsNoTracking().FirstOrDefaultAsync(m => m.Reply_Id == id);

            var domainReply = _mapper.Map<Reply>(newReply);

            domainReply.TimeStamp = oldReply.TimeStamp;

            if (id != domainReply.Reply_Id)
            {
                return BadRequest();
            }
            _context.Entry(domainReply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplyExists(id))
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

        // Replies: api/Reply
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReplyReadDTO>> PostReply([FromBody] ReplyCreateDTO reply)
        {
            var domainReply = _mapper.Map<Reply>(reply);

            domainReply.TimeStamp = DateTime.Now;

            _context.Replies.Add(domainReply);

            await _context.SaveChangesAsync();

            var ReplyToSend = _mapper.Map<ReplyReadDTO>(domainReply);

            return CreatedAtAction("PostReply", new { id = domainReply.Reply_Id }, ReplyToSend);
        }

        // GET: api/Replies/Posts/5
        [HttpGet("post/{id}")]
        public async Task<ActionResult<ReplyReadDTO>> getReplyByPost(int id)
        {
            var reply = await _context.Replies.Include(m => m.Posts).FirstOrDefaultAsync(m => m.Post_Id == id);



            if (reply == null)
            {
                return NotFound();
            }

            var replyToSend = _mapper.Map<ReplyReadDTO>(reply);



            return replyToSend;
        }

        // DELETE: api/Replies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReply(int id)
        {
            var reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }

            _context.Replies.Remove(reply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReplyExists(int id)
        {
            return _context.Replies.Any(e => e.Reply_Id == id);
        }

    }
}
