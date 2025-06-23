using HousingBoardApi.Application.Commands.Document.Create;
using HousingBoardApi.Application.Commands.Document.Delete;
using HousingBoardApi.Application.Queries.Document.GetAllDocuments;
using HousingBoardApi.Application.Queries.Document.GetDocument;


namespace HousingBoardApi.Application.IRepositories;

public interface IDocumentRepository
{
    void Add(CreateDocumentCommand request);
    DocumentEntity Load(Guid id);
    //IEnumerable<DocumentGetAllQueryResultDto> GetAll();
    IEnumerable<GetAllDocumentsByMeetingIdQueryResult> GetAllByMeetingId(Guid id);
    void Edit(DocumentEntity model);

    GetDocumentQueryResult Get(GetDocumentQuery request);
    void Delete(DeleteDocumentCommand request);
}
