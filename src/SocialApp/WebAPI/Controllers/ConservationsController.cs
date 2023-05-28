
using Application.Features.Conservations.Commands.CreateConservation;
using Application.Features.Conservations.Dtos;
using Application.Features.Conservations.Models;
using Application.Features.Conservations.Queries.GetByIdConservation;
using Application.Features.Conservations.Queries.GetListConservation;
using Application.Features.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConservationsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdConservationQuery getByIdConservationQuery)
    {
        ConservationDto result = await Mediator.Send(getByIdConservationQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListConservationQuery getListConservationQuery)
    {
        ConservationListModel allUsers = await Mediator.Send(getListConservationQuery);
        return Ok(allUsers);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateConservationCommand createConservationCommand)
    {
       
        CreatedConservationDto result = await Mediator.Send(createConservationCommand);
        return Created("", result);
    }

   

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteConservationCommand deleteConservationCommand)
    {
        DeletedConservationDto result = await Mediator.Send(deleteConservationCommand);
        return Ok(result);
    }
}