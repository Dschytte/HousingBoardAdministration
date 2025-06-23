namespace HousingBoardApi.Application.Commands.Document.Edit
{
    public record EditDocumentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
