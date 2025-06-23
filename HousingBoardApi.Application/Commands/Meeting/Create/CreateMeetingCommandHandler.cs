using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.Meeting.Create;

public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand>
{
    private readonly IMeetingRepository _meetingRepository;
    private readonly IPublisher _publisher;
    public CreateMeetingCommandHandler(IMeetingRepository meetingRepository, IPublisher publisher)
    {
        _meetingRepository = meetingRepository;
        _publisher = publisher;
    }

    public Task Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
    {
        _meetingRepository.Add(request);

        //Send email
        //_publisher.Publish(new CreateMeetingEmailEvent
        //{
        //    Title = request.Title,
        //    MeetingTime = request.MeetingTime,
        //    AddressLocation = request.AddressLocation,
        //});

        return Task.CompletedTask;
    }
}
