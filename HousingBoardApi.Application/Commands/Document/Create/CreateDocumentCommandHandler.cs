using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.Document.Create;

public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand>
{
    private readonly IDocumentRepository _documentRepository;

    public CreateDocumentCommandHandler(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    Task IRequestHandler<CreateDocumentCommand>.Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        _documentRepository.Add(request);
        return Task.CompletedTask;
    }
}
