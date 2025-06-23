using BookingSystemApi.Application.Commands.Booking.Update;
using BookingSystemApi.Application.IRepositories;

namespace BookingSystemApi.Application.Commands.Booking.Edit;

public class EditBookingCommandHandler : IRequestHandler<EditBookingCommand>
{
    private readonly IBookingRepository _bookingRepository;

    public EditBookingCommandHandler(IBookingRepository resourceRepository)
    {
        _bookingRepository = resourceRepository;
    }

    public Task Handle(EditBookingCommand request, CancellationToken cancellationToken)
    {
        var model = _bookingRepository.Load(request.Id);

        //DoIt
        model.Edit(request.StartDate, request.EndDate);

        //Save
        _bookingRepository.Edit(model);
        return Task.CompletedTask;
    }
}

