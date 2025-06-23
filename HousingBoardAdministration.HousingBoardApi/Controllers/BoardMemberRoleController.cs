using HousingBoardApi.Application.Commands.BoardMemberRole.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardMemberRoleController : Controller
    {
        private readonly IMediator _mediator;

        public BoardMemberRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreateBoardMemberRoleCommand request)
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
}
