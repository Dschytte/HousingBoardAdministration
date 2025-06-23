using HousingBoardApi.Application.Commands.BoardMember.Create;
using HousingBoardApi.Application.Commands.BoardMember.Edit;
using HousingBoardApi.Application.Queries.BoardMember.GetAllBoardMembersWithRoles;
using HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardMemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoardMemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public ActionResult Post([FromBody] CreateBoardMemberCommand request)
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
    [HttpGet]
    public async Task<ActionResult<List<GetAllBoardMembersWithRolesQueryResult>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllBoardMembersWithRolesQuery());
        //if (!result.Any())
        // return NotFound();

        return result.ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBoardMemberWithRoleQueryResult>> Get(Guid id, [FromQuery] bool includeOldRoles)
    {
        var result = await _mediator.Send(new GetBoardMemberWithRoleQuery { Id = id, IncludeOldRoles = includeOldRoles });
        return result;
    }

    [HttpPut]
    public ActionResult Put([FromBody] EditBoardMemberCommand request)
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
