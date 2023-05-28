using Application.Features.Posts.Commands.CreatePost;
using Application.Features.Posts.Commands.UpdatePost;
using Application.Features.Posts.Dtos;
using Application.Features.Posts.Models;
using Application.Features.Posts.Queries.GetByIdPost;
using Application.Features.Posts.Queries.GetListPost;
using Application.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdPostQuery getByIdPostQuery)
    {
        PostDto result = await Mediator.Send(getByIdPostQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListPostQuery getListPostQuery)
    {
        PostListModel allUsers = await Mediator.Send(getListPostQuery);
        return Ok(allUsers);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePostCommand createPostCommand)
    {
        createPostCommand.Files = (IFormCollection?)Request.Form.Files;
        CreatedPostDto result = await Mediator.Send(createPostCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePostCommand updatePostCommand)
    {
        UpdatePostDto result = await Mediator.Send(updatePostCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeletePostCommand deletePostCommand)
    {
        DeletedPostDto result = await Mediator.Send(deletePostCommand);
        return Ok(result);
    }
}