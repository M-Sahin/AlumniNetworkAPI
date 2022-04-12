using AlumniNetworkAPI.Models.Domain;
using AlumniNetworkAPI.Models.DTO.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlumniNetworkAPI.Services

{
    public interface IUserService
    {
        Task Get();
        Task<User> GetInfoAsync(int id);
        Task<bool> UpdateAsync(int id, UserUpdateDTO updatedUser);
        Task<bool> UserExistsAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> FindUserByKeycloakIdAsync(string keycloakId);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
