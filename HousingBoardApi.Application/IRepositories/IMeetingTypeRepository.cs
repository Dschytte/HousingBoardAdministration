using HousingBoardApi.Application.Queries.MeetingType.Dto;


namespace HousingBoardApi.Application.IRepositories;

public interface IMeetingTypeRepository
{
    IEnumerable<MeetingTypeGetAllQueryResultDto> GetAll();
    MeetingTypeGetQueryResultDto Get(Guid id);
}
