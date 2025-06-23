using HousingBoardApi.Application.Commands.Document.Create;
using HousingBoardApi.Application.Commands.Document.Delete;
using HousingBoardApi.Application.Queries.Document.GetAllDocuments;
using HousingBoardApi.Application.Queries.Document.GetDocument;

namespace HousingBoardApi.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly HousingBoardDbContext _dbContext;

    public DocumentRepository(HousingBoardDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    void IDocumentRepository.Add(CreateDocumentCommand request)
    {
        DocumentTypeEntity documentType = new DocumentTypeEntity { Id = request.DocumentTypeId };
        MeetingEntity meeting = new MeetingEntity { Id = request.MeetingId };
        BoardMemberEntity documentOwner = new BoardMemberEntity { Id = request.DocumentOwnerId };

        _dbContext.Attach(documentType);
        _dbContext.Attach(meeting);
        _dbContext.Attach(documentOwner);

        DocumentEntity newDocument = new DocumentEntity
        {
            Title = request.Title,
            DocumentType = documentType,
            DocumentFile = Convert.FromBase64String(request.DocumentFile),
            UploadDate = DateTime.Now,
            Meeting = meeting,
            DocumentOwner = documentOwner
        };

        _dbContext.Add(newDocument);
        _dbContext.SaveChanges();
    }

    void IDocumentRepository.Delete(DeleteDocumentCommand request)
    {
        _dbContext.Remove(_dbContext.DocumentEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
        _dbContext.SaveChanges();
    }

    GetDocumentQueryResult IDocumentRepository.Get(GetDocumentQuery request)
    {

        var model = _dbContext.DocumentEntities
            .Include(type => type.DocumentType)
            .Include(meeting => meeting.Meeting)
            .Include(documentowner => documentowner.DocumentOwner)
            .AsNoTracking().FirstOrDefault(x => x.Id == request.Id);


        if (model == null) throw new Exception("No document found");

        return new GetDocumentQueryResult
        {
            Id = model.Id,
            Title = model.Title,
            DocumentType = new DocumentTypeDto { Id = model.DocumentType.Id, Type = model.DocumentType.Type },
            DocumentFile = model.DocumentFile,
            UploadDate = model.UploadDate,
            UserOwnerId = model.DocumentOwner.Id,
            Meeting = new MeetingDto { Id = model.Meeting.Id, Description = model.Meeting.Description, Title = model.Meeting.Title }
        };

    }


    IEnumerable<GetAllDocumentsByMeetingIdQueryResult> IDocumentRepository.GetAllByMeetingId(Guid meetingId)
    {

        var documentModels = _dbContext.DocumentEntities
            .Include(type => type.DocumentType)
            .AsNoTracking().Where(x => x.Meeting.Id == meetingId);


        foreach (var model in documentModels)
        {
            yield return new GetAllDocumentsByMeetingIdQueryResult
            {
                Id = model.Id,
                Title = model.Title,
                DocumentType = new DocumentTypeDto { Id = model.DocumentType.Id, Type = model.DocumentType.Type },
                DocumentFile = model.DocumentFile,
                UploadDate = model.UploadDate
            };
        }

    }

    DocumentEntity IDocumentRepository.Load(Guid id)
    {
        DocumentEntity model = _dbContext.DocumentEntities.FirstOrDefault(x => x.Id == id);

        return model == null ? throw new Exception("No document found") : model;
    }

    void IDocumentRepository.Edit(DocumentEntity model)
    {
        _dbContext.Update(model);
        _dbContext.SaveChanges();
    }
}
