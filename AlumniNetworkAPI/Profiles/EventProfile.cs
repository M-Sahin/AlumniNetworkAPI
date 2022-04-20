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
            CreateMap<Event, EventCreateDTO>()
                .ReverseMap();

            CreateMap<Event, EventReadDTO>()
                .ReverseMap();

            CreateMap<Event, EventUpdateDTO>()
                .ReverseMap();
        }
    }
}