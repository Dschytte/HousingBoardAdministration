using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Application.Queries.Meeting.GetMeeting;

public class GetMeetingQueryResult
{
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public MeetingTypeDto MeetingType { get; set; }
    public List<DocumentDto> Documents { get; set; }
    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }
    public DateTime CreatedMeetingDate { get; set; }

}