using AlumniNetworkAPI.Models.DTO.Group;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;



using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupCreateDTO>()
                .ReverseMap();
            CreateMap<Group, GroupReadDTO>()
                .ReverseMap();
            CreateMap<Group, GroupUpdateDTO>()
                .ReverseMap();
        }

    }
}
