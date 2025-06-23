using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Queries.Document.GetAllDocuments;

namespace HousingBoardApi.Application.Queries.Document.GetAllDocumentsByMeetingId;

public class GetAllDocumentsByMeetingIdQueryHandler : IRequestHandler<GetAllDocumentsByMeetingIdQuery, List<GetAllDocumentsByMeetingIdQueryResult>>
{
    private readonly IDocumentRepository _documentRepository;

    public GetAllDocumentsByMeetingIdQueryHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    Task<List<GetAllDocumentsByMeetingIdQueryResult>> IRequestHandler<GetAllDocumentsByMeetingIdQuery, List<GetAllDocumentsByMeetingIdQueryResult>>.Handle(GetAllDocumentsByMeetingIdQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_documentRepository.GetAllByMeetingId(request.MeetingId).ToList());
    }
}
