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
                .ReverseMap();

            CreateMap<Reply, ReplyUpdateDTO>()
                .ReverseMap();
        }
    }
}

