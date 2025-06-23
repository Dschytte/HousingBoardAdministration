using BookingSystemApi.Application.Commands.Resident.Create;
using BookingSystemApi.Application.Commands.Resident.Delete;
using BookingSystemApi.Application.Commands.Resident.Edit;
using BookingSystemApi.Application.Queris.Resident.GetAllResident;
using BookingSystemApi.Application.Queris.Resident.GetResident;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.BookingSystemApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResidentController : ControllerBase
{
    private readonly IMediator _mediator;


    public ResidentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public ActionResult Post([FromBody] CreateResidentCommand request)
    {
        try
        {
            _mediator.Send(request);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public ActionResult Put([FromBody] EditResidentCommand request)
    {
        try
        {
            _mediator.Send(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpDelete]
    public ActionResult Delete([FromBody] DeleteResidentCommand request)
    {
        try
        {
            _mediator.Send(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetResidentQueryHandler>> Get(Guid id)
    {
        var result = await _mediator.Send(new GetResidentQuery { Id = id });
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllResidentQueryResult>>> GetAll([FromQuery] GetAllResidentQuery request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

}
