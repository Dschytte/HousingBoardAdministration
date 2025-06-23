
using HousingBoardApi.Application.Queries.MeetingType.Dto;
using HousingBoardApi.Application.Queries.MeetingType.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingTypeController : ControllerBase
    {
        private readonly IMeetingTypeGetAllQuery _meetingTypeGetAllQuery;
        private readonly IMeetingTypeGetQuery _meetingTypeGetQuery;


        public MeetingTypeController(IMeetingTypeGetAllQuery meetingTypeGetAllQuery, IMeetingTypeGetQuery meetingTypeGetQuery)
        {
            _meetingTypeGetAllQuery = meetingTypeGetAllQuery;
            _meetingTypeGetQuery = meetingTypeGetQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeetingTypeGetAllQueryResultDto>> GetAll()
        {
            var result = _meetingTypeGetAllQuery.GetAll();
            //if (!result.Any())
            // return NotFound();

            return result.ToList();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public ActionResult<MeetingTypeGetQueryResultDto> Get(Guid id)
        {
            var result = _meetingTypeGetQuery.Get(id);
            return result;
        }
    }
}
