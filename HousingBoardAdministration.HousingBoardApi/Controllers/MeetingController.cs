using HousingBoardApi.Application.Commands.Meeting.Create;
using HousingBoardApi.Application.Commands.Meeting.Delete;
using HousingBoardApi.Application.Commands.Meeting.Edit;
using HousingBoardApi.Application.Queries.Meeting.GetAllMeetings;
using HousingBoardApi.Application.Queries.Meeting.GetMeeting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {

        private readonly IMediator _mediator;

        public MeetingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] DeleteMeetingCommand request)
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

        [HttpPost]
        public ActionResult Post([FromBody] CreateMeetingCommand request)
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
        public ActionResult Put([FromBody] EditMeetingCommand request)
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
        public async Task<ActionResult<IEnumerable<GetAllMeetingsQueryResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllMeetingsQuery());
            return result.ToList();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMeetingQueryResult>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetMeetingQuery { Id = id });
            return result;
        }
    }
}
