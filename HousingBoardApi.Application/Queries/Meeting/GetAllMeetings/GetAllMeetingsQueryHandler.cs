
using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Queries.Meeting.GetAllMeetings;

public class GetAllMeetingsQueryHandler : IRequestHandler<GetAllMeetingsQuery, List<GetAllMeetingsQueryResult>>
{
    private readonly IMeetingRepository _meetingRepository;

    public GetAllMeetingsQueryHandler(IMeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }

    Task<List<GetAllMeetingsQueryResult>> IRequestHandler<GetAllMeetingsQuery, List<GetAllMeetingsQueryResult>>.Handle(GetAllMeetingsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_meetingRepository.GetAll(request).ToList());
    }
}
