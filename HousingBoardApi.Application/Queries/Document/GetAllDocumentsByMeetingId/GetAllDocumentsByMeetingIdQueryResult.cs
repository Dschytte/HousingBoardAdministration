
using HousingBoardApi.Application.Queries.Document.GetDocument;

namespace HousingBoardApi.Application.Queries.Document.GetAllDocuments;

public record GetAllDocumentsByMeetingIdQueryResult
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DocumentTypeDto DocumentType { get; set; }
    public byte[] DocumentFile { get; set; }
    public DateTime UploadDate { get; set; }
}
