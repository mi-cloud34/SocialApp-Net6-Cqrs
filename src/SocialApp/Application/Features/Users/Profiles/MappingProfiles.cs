﻿using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Commands.UpdateUserFromAuth;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, CreatedUserDto>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();
        CreateMap<User, UpdatedUserDto>().ReverseMap();
        CreateMap<User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<User, UpdatedUserFromAuthDto>().ReverseMap();
        CreateMap<User, DeleteUserCommand>().ReverseMap();
        CreateMap<User, DeletedUserDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, Dtos.UserListDto>()
            .ForMember(c => c.Followers, opt => opt.MapFrom(c => c.Follow.Followers))
            .ForMember(c => c.Following, opt => opt.MapFrom(c => c.Follow.Following));
        CreateMap<User, Models.UserListModel>().ReverseMap();
    }
}