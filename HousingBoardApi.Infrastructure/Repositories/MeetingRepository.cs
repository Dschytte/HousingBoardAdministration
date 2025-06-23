using HousingBoardApi.Application.Commands.Meeting.Create;
using HousingBoardApi.Application.Commands.Meeting.Delete;
using HousingBoardApi.Application.Queries.Document.GetDocument;
using HousingBoardApi.Application.Queries.Meeting;
using HousingBoardApi.Application.Queries.Meeting.GetAllMeetings;
using HousingBoardApi.Application.Queries.Meeting.GetMeeting;


namespace HousingBoardApi.Infrastructure.Repositories;

public class MeetingRepository : IMeetingRepository
{
    private readonly HousingBoardDbContext _db;

    public MeetingRepository(HousingBoardDbContext db)
    {
        _db = db;
    }

    MeetingEntity IMeetingRepository.Load(Guid id)
    {
        //var dbEntity = _db.MeetingEntities.AsNoTracking().FirstOrDefault(x => x.Id == id);
        var model = _db.MeetingEntities.FirstOrDefault(x => x.Id == id);

        //conditional operator : at vælge mellem to værdier eller udføre to forskellige handlinger afhængigt af en betingelse
        return model == null ? throw new Exception("Ingen meeting fundet i databasen") : model;
    }

    void IMeetingRepository.Update(MeetingEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }


    void IMeetingRepository.Delete(DeleteMeetingCommand request)
    {
        try
        {
            _db.Remove(_db.MeetingEntities.AsNoTracking().FirstOrDefault(x => x.Id == request.Id));
            _db.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Der var et dokument under mødet");
        }

    }

    void IMeetingRepository.Add(CreateMeetingCommand request)
    {

        MeetingTypeEntity meetingType = new MeetingTypeEntity { Id = request.MeetingTypeId };
        BoardMemberEntity meetingOwner = new BoardMemberEntity { Id = request.MeetingOwnerId };

        _db.Attach(meetingType);
        _db.Attach(meetingOwner);

        var model = new MeetingEntity
        {
            Title = request.Title,
            Description = request.Description,
            AddressLocation = request.AddressLocation,
            MeetingOwner = meetingOwner,
            MeetingType = meetingType,
            CreatedMeetingDate = DateTime.Now,
            MeetingTime = request.MeetingTime,
            IsDeleted = false,
            DeletedAt = null

        };

        _db.Add(model);
        _db.SaveChanges();
    }

    GetMeetingQueryResult IMeetingRepository.Get(GetMeetingQuery request)
    {
        var model = _db.MeetingEntities
            .Include(type => type.MeetingType)
            .Include(document => document.Documents).ThenInclude(dtype => dtype.DocumentType)
            .AsNoTracking().FirstOrDefault(x => x.Id == request.Id);


        if (model == null) throw new Exception("No meeting found");

        return new GetMeetingQueryResult
        {
            Id = model.Id,
            Title = model.Title,
            MeetingType = new MeetingTypeDto { Id = model.MeetingType.Id, Type = model.MeetingType.Type },
            AddressLocation = model.AddressLocation,
            CreatedMeetingDate = model.CreatedMeetingDate,
            MeetingTime = model.MeetingTime,
            Description = model.Description,
            RowVersion = model.RowVersion,

            Documents = model.Documents.Select(doc => new DocumentDto
            {
                Id = doc.Id,
                Title = doc.Title,
                UploadDate = doc.UploadDate,
                DocumentType = new DocumentTypeDto
                {
                    Id = doc.DocumentType.Id,
                    Type = doc.DocumentType.Type
                },
            }).ToList()

        };
    }

    IEnumerable<GetAllMeetingsQueryResult> IMeetingRepository.GetAll(GetAllMeetingsQuery request)
    {
        var meetingModels = _db.MeetingEntities
            .Include(type => type.MeetingType)
            .AsNoTracking();


        foreach (var model in meetingModels)
        {
            yield return new GetAllMeetingsQueryResult
            {
                Id = model.Id,
                Title = model.Title,
                MeetingType = new MeetingTypeDto { Id = model.MeetingType.Id, Type = model.MeetingType.Type },
                AddressLocation = model.AddressLocation,
                CreatedMeetingDate = model.CreatedMeetingDate,
                MeetingTime = model.MeetingTime,
                Description = model.Description
            };
        }
    }
}
