using AlumniNetworkAPI.Models.DTO.Replies;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class ReplyProfile : Profile
    {
        public ReplyProfile()
        {
            CreateMap<Reply, ReplyCreateDTO>()
                .ReverseMap();

            CreateMap<Reply, ReplyReadDTO>()
                .ForMember(fdto => fdto.Posts, opt => opt
                .MapFrom(f => f.Posts.Select(m => m.Replies).ToArray()))
                .ReverseMap();

            CreateMap<Reply, ReplyUpdateDTO>()
                .ReverseMap();
        }
    }
}

