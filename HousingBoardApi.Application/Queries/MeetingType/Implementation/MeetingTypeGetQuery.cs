
using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Queries.MeetingType.Dto;
using HousingBoardApi.Application.Queries.MeetingType.Interface;

namespace HousingBoardApi.Application.Queries.MeetingType.Implementation;

public class MeetingTypeGetQuery : IMeetingTypeGetQuery
{
    private readonly IMeetingTypeRepository _meetingTypeRepository;

    public MeetingTypeGetQuery(IMeetingTypeRepository meetingTypeRepository)
    {
        _meetingTypeRepository = meetingTypeRepository;
    }
    MeetingTypeGetQueryResultDto IMeetingTypeGetQuery.Get(Guid id)
    {
        return _meetingTypeRepository.Get(id);
    }
}
