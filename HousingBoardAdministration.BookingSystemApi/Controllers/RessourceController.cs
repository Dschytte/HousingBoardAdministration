using BookingSystemApi.Application.Commands.Resource.Create;
using BookingSystemApi.Application.Commands.Resource.Delete;
using BookingSystemApi.Application.Commands.Resource.Edit;
using BookingSystemApi.Application.Queris.Resource.GetAllResourcesQuery;
using BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.BookingSystemApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RessourceController : ControllerBase
    {
        private readonly IMediator _mediator;


        public RessourceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public ActionResult Post([FromBody] CreateResourceCommand request)
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
        [HttpDelete]
        public ActionResult Delete([FromBody] DeleteResourceCommad request)
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
        public ActionResult Put([FromBody] EditResourceCommand request)
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllResourcesQueryResult>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllResourcesQuery());
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetResourcesQueryResult>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetResourcesQuery { Id = id });
            return result;
        }
    }
}

