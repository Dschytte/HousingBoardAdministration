
namespace HousingBoardApi.Application.Queries.MeetingType.Dto;

public record MeetingTypeGetQueryResultDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }

}
