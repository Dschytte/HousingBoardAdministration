namespace HousingBoardApi.Application.Commands.Document.Delete
{
    public record DeleteDocumentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
