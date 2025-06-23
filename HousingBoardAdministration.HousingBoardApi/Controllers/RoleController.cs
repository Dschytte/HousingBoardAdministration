using HousingBoardApi.Application.Queries.Role.Dto;
using HousingBoardApi.Application.Queries.Role.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleGetAllQuery _roleGetAllQuery;
        private readonly IRoleGetQuery _roleGetQuery;

        public RoleController(IRoleGetAllQuery roleGetAllQuery, IRoleGetQuery roleGetQuery)
        {
            _roleGetAllQuery = roleGetAllQuery;
            _roleGetQuery = roleGetQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleGetAllQueryResultDto>> GetAll()
        {
            var result = _roleGetAllQuery.GetAll();
            //if (!result.Any())
            // return NotFound();

            return result.ToList();
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public ActionResult<RoleGetQueryResultDto> Get(Guid id)
        {
            var result = _roleGetQuery.Get(id);
            return result;
        }
    }
}
