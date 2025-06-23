namespace HousingBoardApi.Application.Commands.Meeting.Delete;

public record DeleteMeetingCommand : IRequest
{
    public Guid Id { get; set; }
}
