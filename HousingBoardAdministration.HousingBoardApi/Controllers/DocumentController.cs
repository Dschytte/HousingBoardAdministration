using HousingBoardApi.Application.Commands.Document.Create;
using HousingBoardApi.Application.Commands.Document.Delete;
using HousingBoardApi.Application.Commands.Document.Edit;
using HousingBoardApi.Application.Queries.Document.GetAllDocuments;
using HousingBoardApi.Application.Queries.Document.GetDocument;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentController : ControllerBase
{

    private readonly IMediator _mediator;

    public DocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetDocumentQueryResult>> Get(Guid id)
    {
        var result = await _mediator.Send(new GetDocumentQuery { Id = id });
        return result;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllDocumentsByMeetingIdQueryResult>>> GetAll([FromQuery] GetAllDocumentsByMeetingIdQuery request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPost]
    public ActionResult Post([FromBody] CreateDocumentCommand request)
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

    [HttpPut]
    public ActionResult Put([FromBody] EditDocumentCommand request)
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
    public ActionResult Delete([FromBody] DeleteDocumentCommand request)
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

}
