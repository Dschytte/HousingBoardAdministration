

namespace HousingBoardApi.Application.Queries.MeetingType.Dto;

public record MeetingTypeGetAllQueryResultDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
}
