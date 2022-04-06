using AlumniNetworkAPI.Models.DTO.Post;
using AlumniNetworkAPI.Models.Domain;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AlumniNetworkAPI.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostCreateDTO>()
                .ReverseMap();

            CreateMap<Post, PostReadDTO>()
                .ForMember(fdto => fdto.Replies, opt => opt
                .MapFrom(f => f.Replies.Select(m => m.Post_Id).ToArray()))
                .ReverseMap();

            CreateMap<Post, PostUpdateDTO>()
                .ReverseMap();
        }
    }
}
