using HousingBoardApi.Application.Queries.DocumentType.GetAllDocumentTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HousingBoardAdministration.HousingBoardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllDocumentTypesQueryResult>>> GetAll([FromQuery] GetAllDocumentTypesQuery request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
