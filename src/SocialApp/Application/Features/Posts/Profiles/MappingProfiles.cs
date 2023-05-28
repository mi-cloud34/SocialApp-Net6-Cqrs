using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Posts.Commands.CreatePost;
using Application.Features.Posts.Commands.UpdatePost;
using Application.Features.Posts.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Posts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, CreatePostCommand>().ReverseMap();
        CreateMap<Post, DeletePostCommand>().ReverseMap();
        CreateMap<Post, UpdatePostCommand>().ReverseMap();
        CreateMap<Post, DeletedPostDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostListDto>().ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.FirstName));
        CreateMap<Post, Models.PostListModel>();
    }
}