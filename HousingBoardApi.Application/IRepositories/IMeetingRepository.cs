using HousingBoardApi.Application.Commands.Meeting.Create;
using HousingBoardApi.Application.Commands.Meeting.Delete;
using HousingBoardApi.Application.Queries.Meeting.GetAllMeetings;
using HousingBoardApi.Application.Queries.Meeting.GetMeeting;


namespace HousingBoardApi.Application.IRepositories;

public interface IMeetingRepository
{
    //void Add(ResourceCreateRequestDto resource);
    MeetingEntity Load(Guid id);
    IEnumerable<GetAllMeetingsQueryResult> GetAll(GetAllMeetingsQuery request);
    void Update(MeetingEntity model);

    GetMeetingQueryResult Get(GetMeetingQuery request);
    void Delete(DeleteMeetingCommand request);
    void Add(CreateMeetingCommand request);
}
