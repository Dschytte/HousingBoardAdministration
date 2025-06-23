
using HousingBoardApi.Application.Queries.MeetingType.Dto;

namespace HousingBoardApi.Application.Queries.MeetingType.Interface;

public interface IMeetingTypeGetQuery
{
    MeetingTypeGetQueryResultDto Get(Guid id);

}
