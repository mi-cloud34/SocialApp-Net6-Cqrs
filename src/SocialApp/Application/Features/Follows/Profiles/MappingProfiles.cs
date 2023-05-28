
using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Follows.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Follow, CreateFollowCommand>().ReverseMap();
        CreateMap<Follow, CreatedFollowDto>().ReverseMap();
        CreateMap<Follow, DeleteFollowCommand>().ReverseMap();
        CreateMap<Follow, DeletedFollowDto>().ReverseMap();
        CreateMap<Follow, FollowDto>().ReverseMap();
       // CreateMap<Follow, FollowListDto>().ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.FirstName));
        CreateMap<Follow, Models.FollowListModel>();
    }
}