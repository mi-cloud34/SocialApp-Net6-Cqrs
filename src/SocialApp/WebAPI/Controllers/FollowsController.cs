using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Dtos;
using Application.Features.Follows.Models;
using Application.Features.Follows.Queries.GetByIdFollow;
using Application.Features.Follows.Queries.GetListFollow;
using Application.Features.Messages.Models;
using Application.Features.Messages.Queries.GetListMessage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdFollowQuery getByIdFollowQuery)
    {
        FollowDto result = await Mediator.Send(getByIdFollowQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListFollowQuery getListFollowQuery)
    {
        FollowListModel allFollow = await Mediator.Send(getListFollowQuery);
        return Ok(allFollow);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFollowCommand createFollowCommand)
    {
        CreatedFollowDto result = await Mediator.Send(createFollowCommand);
        return Created("", result);
    }

  

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFollowCommand deleteFollowCommand)
    {
        DeletedFollowDto result = await Mediator.Send(deleteFollowCommand);
        return Ok(result);
    }
}