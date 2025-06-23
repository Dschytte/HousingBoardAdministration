
using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Queries.MeetingType.Dto;
using HousingBoardApi.Application.Queries.MeetingType.Interface;

namespace HousingBoardApi.Application.Queries.MeetingType.Implementation;

public class MeetingTypeGetAllQuery : IMeetingTypeGetAllQuery
{
    private readonly IMeetingTypeRepository _meetingTypeRepository;

    public MeetingTypeGetAllQuery(IMeetingTypeRepository meetingTypeRepository)
    {
        _meetingTypeRepository = meetingTypeRepository;
    }
    IEnumerable<MeetingTypeGetAllQueryResultDto> IMeetingTypeGetAllQuery.GetAll()
    {
        return _meetingTypeRepository.GetAll();
    }
}
