

using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Queries.DocumentType.GetAllDocumentTypes;

public class GetAllDocumentTypesQueryHandler : IRequestHandler<GetAllDocumentTypesQuery, List<GetAllDocumentTypesQueryResult>>
{
    private readonly IDocumentTypeRepository _documentTypeRepository;

    public GetAllDocumentTypesQueryHandler(IDocumentTypeRepository documentTypeRepository)
    {
        _documentTypeRepository = documentTypeRepository;
    }

    Task<List<GetAllDocumentTypesQueryResult>> IRequestHandler<GetAllDocumentTypesQuery, List<GetAllDocumentTypesQueryResult>>.Handle(GetAllDocumentTypesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_documentTypeRepository.GetAll(request).ToList());
    }
}
