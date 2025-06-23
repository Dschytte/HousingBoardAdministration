namespace HousingBoardApi.Application.Queries.Meeting.GetAllMeetings;

public class GetAllMeetingsQueryResult
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public MeetingTypeDto MeetingType { get; set; }
    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }
    public DateTime CreatedMeetingDate { get; set; }
}