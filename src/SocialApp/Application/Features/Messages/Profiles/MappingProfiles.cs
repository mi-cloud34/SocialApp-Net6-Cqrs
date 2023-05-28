using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Messages.Commands.CreateMessage;
using Application.Features.Messages.Dtos;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Messages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
      
        CreateMap<Message, DeleteMessageCommand>().ReverseMap();
        CreateMap<Message, DeletedMessageDto>().ReverseMap();
        CreateMap<Message, MessageDto>().ReverseMap();
        CreateMap<Message, MessageListDto>().ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.FirstName));
        CreateMap<Message, Models.MessageListModel>();
    }
}