namespace HousingBoardApi.Application.Queries.Document.GetAllDocuments;

public record GetAllDocumentsByMeetingIdQuery : IRequest<List<GetAllDocumentsByMeetingIdQueryResult>>
{
    public Guid MeetingId { get; set; }
}
