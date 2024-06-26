﻿using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Commands.UpdateUserFromAuth;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetByIdUser;
using Application.Features.Users.Queries.GetListUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
    {
        UserDto result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet("GetFromAuth")]
    public async Task<IActionResult> GetFromAuth()
    {
        GetByIdUserQuery getByIdUserQuery = new() { Id = getUserIdFromRequest() };
        UserDto result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet]
   
    public async Task<IActionResult> GetList([FromQuery] GetListUserQuery getListUserQuery)
    {
        UserListModel allUsers = await Mediator.Send(getListUserQuery);
        return Ok(allUsers);
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        createUserCommand.Files = (IFormFile?)Request.Form.Files;
        CreatedUserDto result = await Mediator.Send(createUserCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserDto result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }

    [HttpPut("FromAuth")]
    public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
    {
        updateUserFromAuthCommand.Id = getUserIdFromRequest();
        UpdatedUserFromAuthDto result = await Mediator.Send(updateUserFromAuthCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        DeletedUserDto result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }
}