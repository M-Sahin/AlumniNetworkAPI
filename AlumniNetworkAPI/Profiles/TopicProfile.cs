using AlumniNetworkAPI.Models.DTO.Topic;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;



using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicCreateDTO>()
                .ReverseMap();
            CreateMap<Topic, TopicReadDTO>()
                .ReverseMap();
            CreateMap<Topic, TopicUpdateDTO>()
                .ReverseMap();
        }

    }
}
