using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.Meeting.Delete;

public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand>
{
    private readonly IMeetingRepository _meetingRepository;

    public DeleteMeetingCommandHandler(IMeetingRepository meetingRepository)
    {
        _meetingRepository = meetingRepository;
    }

    public Task Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
    {
        _meetingRepository.Delete(request);
        return Task.CompletedTask;
    }
}
