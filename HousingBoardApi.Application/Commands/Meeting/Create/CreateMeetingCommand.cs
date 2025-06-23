namespace HousingBoardApi.Application.Commands.Meeting.Create;

public record class CreateMeetingCommand : IRequest
{
    public string Title { get; set; }
    public string Description { get; set; }

    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }

    public Guid MeetingTypeId { get; set; }
    public Guid MeetingOwnerId { get; set; }
}
