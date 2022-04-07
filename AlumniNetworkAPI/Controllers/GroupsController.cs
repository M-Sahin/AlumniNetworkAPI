using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.Group;
using AutoMapper;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;

        public GroupsController(AlumniNetworkDbContext context, IMapper mapper)

        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }


        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupReadDTO>> PostGroup([FromBody] GroupCreateDTO group)
        {
            var domainGroup = _mapper.Map<Group>(group);

            _context.Groups.Add(domainGroup);

            await _context.SaveChangesAsync();

            var GroupToSend = _mapper.Map<GroupReadDTO>(domainGroup);

            return CreatedAtAction("GetGroup", new { id = domainGroup.group_id }, GroupToSend);
        }

        // POST: api/Group
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{userId}/{groupId}")]
        public async Task<ActionResult<GroupUser>> JoinGroup(int userId, int groupId)
        {
            GroupUser groupUser = new GroupUser();
            groupUser.Groupsgroup_id = groupId;
            groupUser.UseruserId = userId;

           // _context.GroupUsers.Add(groupUser);

            await _context.SaveChangesAsync();


            return Ok();
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.group_id == id);
        }
    }
}