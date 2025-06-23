using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.Document.Delete
{
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        private readonly IDocumentRepository _documentRepository;

        public DeleteDocumentCommandHandler(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        Task IRequestHandler<DeleteDocumentCommand>.Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            _documentRepository.Delete(request);
            return Task.CompletedTask;
        }
    }
}
