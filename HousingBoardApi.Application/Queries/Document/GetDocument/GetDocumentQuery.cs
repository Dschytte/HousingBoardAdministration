namespace HousingBoardApi.Application.Queries.Document.GetDocument;

public record GetDocumentQuery : IRequest<GetDocumentQueryResult>
{
    public Guid Id { get; set; }

}
