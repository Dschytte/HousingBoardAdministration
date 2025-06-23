using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Domain.DomainService;

namespace BookingSystemApi.Application.Commands.Booking.Create;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IBookingDateValidationService _bookingDateValidationService;

    public CreateBookingCommandHandler(IBookingRepository resourceRepository, IBookingDateValidationService bookingDateValidationService)
    {
        _bookingRepository = resourceRepository;
        _bookingDateValidationService = bookingDateValidationService;
    }

    Task<bool> IRequestHandler<CreateBookingCommand, bool>.Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {

        foreach (var resourceid in request.ResourceIdsList)
        {
            var isResourceAvailable = _bookingDateValidationService.IsResourceAvailableAsync(resourceid, request.StartDate, request.EndDate);

            if (!isResourceAvailable)
            {
                return Task.FromResult(false);
            }
        }

        return Task.FromResult(_bookingRepository.Create(request));
    }
}

