using AlumniNetworkAPI.Models;
using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.User;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlumniNetworkAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AlumniNetworkDbContext _context;
        public UserService(AlumniNetworkDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> FindUserByKeycloakIdAsync(string keycloakId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.KeycloakId == keycloakId);
        }

        public Task Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(t => t.Topics).Include(t => t.Groups).ToListAsync();
        }

        public async Task<User> GetInfoAsync(int id)
        {
            return await _context.Users.Include(t => t.Topics).Include(t => t.Groups).FirstOrDefaultAsync(u => u.userId == id);
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDTO updatedUser)
        {
            var foundUser = await _context.Users.FirstOrDefaultAsync(u => u.userId == id);
            if (foundUser != null)
            {
                if (updatedUser.bio != foundUser.bio)
                    foundUser.bio = updatedUser.bio;

                if (updatedUser.fun_fact != foundUser.fun_fact)
                    foundUser.fun_fact = updatedUser.fun_fact;

                if (updatedUser.picture != foundUser.picture)
                    foundUser.picture = updatedUser.picture;

                if (updatedUser.name != foundUser.name)
                    foundUser.name = updatedUser.name;

                if (updatedUser.status != foundUser.status)
                    foundUser.status = updatedUser.status;

                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.userId == id) != null;
        }
    }
}
