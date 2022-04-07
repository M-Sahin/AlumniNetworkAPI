using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.User;
using AutoMapper;
using System.Security.Claims;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using AlumniNetworkAPI.Services;
using AlumniNetworkAPI.Extensions;


namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly AlumniNetworkDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(AlumniNetworkDbContext context, IMapper mapper, IUserService userService)

        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        //GET for fetching authenticated user
        [HttpGet]
        public async Task<IActionResult> GetUserAsync()
        {
            string keycloakId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = await _userService.FindUserByKeycloakIdAsync(keycloakId);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Access denied: Could not verify user.");
            }
            return this.SeeOther($"/api/[controller]/{user.userId}");
        }


        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UserUpdate(int id, UserUpdateDTO newUser)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }

            var domainUser = _mapper.Map<User>(newUser);

            if (id != domainUser.userId)
            {
                return BadRequest();
            }

            _context.Entry(domainUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> PostUser([FromBody] UserCreateDTO user)
        {
            var domainUser = _mapper.Map<User>(user);

            _context.Users.Add(domainUser);

            await _context.SaveChangesAsync();

            var UserToSend = _mapper.Map<UserReadDTO>(domainUser);

            return CreatedAtAction("GetUser", new { id = domainUser.userId }, UserToSend);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.userId == id);
        }
    }
}
