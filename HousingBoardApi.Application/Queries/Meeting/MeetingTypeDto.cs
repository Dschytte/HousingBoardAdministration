namespace HousingBoardApi.Application.Queries.Meeting;

public record MeetingTypeDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
}
