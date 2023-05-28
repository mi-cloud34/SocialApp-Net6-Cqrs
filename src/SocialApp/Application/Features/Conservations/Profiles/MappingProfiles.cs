using Application.Features.Conservations.Commands.CreateConservation;
using Application.Features.Conservations.Dtos;
using Application.Features.Conservations.Models;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Conservations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Conservation, CreateConservationCommand>().ReverseMap();
        CreateMap<Conservation, CreatedConservationDto>().ReverseMap();
        CreateMap<Conservation, DeletedConservationCommand>().ReverseMap();
        CreateMap<Conservation, DeletedConservationDto>().ReverseMap();
        CreateMap<Conservation, ConservationDto>().ReverseMap();
        CreateMap<Conservation, ConservationListDto>()
            .ForMember(c => c.SenderName, opt => opt.MapFrom(c => c.User.FirstName))
            .ForMember(c => c.ReceiveName, opt => opt.MapFrom(c => c.User.FirstName));
        CreateMap<Conservation, ConservationListModel>();
    }
}