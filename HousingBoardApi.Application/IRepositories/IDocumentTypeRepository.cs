using HousingBoardApi.Application.Queries.DocumentType.GetAllDocumentTypes;

namespace HousingBoardApi.Application.IRepositories;

public interface IDocumentTypeRepository
{
    IEnumerable<GetAllDocumentTypesQueryResult> GetAll(GetAllDocumentTypesQuery request);
}
