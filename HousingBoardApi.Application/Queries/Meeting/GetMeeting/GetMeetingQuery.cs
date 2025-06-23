namespace HousingBoardApi.Application.Queries.Meeting.GetMeeting;

public record GetMeetingQuery : IRequest<GetMeetingQueryResult>
{
    public Guid Id { get; set; }
}
