using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Queries.Meeting.GetMeeting;

public class GetMeetingQueryHandler : IRequestHandler<GetMeetingQuery, GetMeetingQueryResult>
{
    private readonly IMeetingRepository _meetingRepository;

    public GetMeetingQueryHandler(IMeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }

    Task<GetMeetingQueryResult> IRequestHandler<GetMeetingQuery, GetMeetingQueryResult>.Handle(GetMeetingQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_meetingRepository.Get(request));
    }
}
