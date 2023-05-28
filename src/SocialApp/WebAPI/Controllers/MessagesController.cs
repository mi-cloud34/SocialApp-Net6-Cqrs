

using Application.Features.Messages.Dtos;
using Application.Features.Messages.Models;
using Application.Features.Messages.Queries.GetByIdMessage;
using Application.Features.Messages.Queries.GetListMessage;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetListUser;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdMessageQuery getByIdMessageQuery)
    {
        MessageDto result = await Mediator.Send(getByIdMessageQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListMessageQuery getListMessageQuery)
    {
        MessageListModel allMessage = await Mediator.Send(getListMessageQuery);
        return Ok(allMessage);
    }


    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteMessageCommand deleteMessageCommand)
    {
        DeletedMessageDto result = await Mediator.Send(deleteMessageCommand);
        return Ok(result);
    }
}