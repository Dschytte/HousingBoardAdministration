
using HousingBoardApi.Application.Queries.DocumentType.GetAllDocumentTypes;

namespace HousingBoardApi.Infrastructure.Repositories;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly HousingBoardDbContext _db;

    public DocumentTypeRepository(HousingBoardDbContext db)
    {
        _db = db;
    }

    IEnumerable<GetAllDocumentTypesQueryResult> IDocumentTypeRepository.GetAll(GetAllDocumentTypesQuery request)
    {
        var documentTypes = _db.DocumentTypeEntities
            .AsNoTracking();

        foreach (var model in documentTypes)
        {
            yield return new GetAllDocumentTypesQueryResult
            {
                Id = model.Id,
                Type = model.Type
            };
        }
    }
}
