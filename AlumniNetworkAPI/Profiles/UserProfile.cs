using AlumniNetworkAPI.Models.DTO.User;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;



using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserCreateDTO>()
                .ReverseMap();
            CreateMap<User, UserReadDTO>()    
                .ReverseMap();
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
        }

    }
}
