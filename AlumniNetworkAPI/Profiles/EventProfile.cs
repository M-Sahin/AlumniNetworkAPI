using AlumniNetworkAPI.Models.DTO.Event;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Post, EventCreateDTO>()
                .ReverseMap();

            CreateMap<Post, EventReadDTO>()
                .ReverseMap();

            CreateMap<Post, EventUpdateDTO>()
                .ReverseMap();
        }
    }
}