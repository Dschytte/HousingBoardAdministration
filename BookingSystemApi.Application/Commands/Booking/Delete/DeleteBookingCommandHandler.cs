

using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Booking.Delete;

public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
{

    private readonly IBookingRepository _bookingRepository;

    public DeleteBookingCommandHandler(IBookingRepository resourceRepository)
    {
        _bookingRepository = resourceRepository;
    }

    public Task Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
    {
        _bookingRepository.Delete(request);
        return Task.CompletedTask;


    }
}

