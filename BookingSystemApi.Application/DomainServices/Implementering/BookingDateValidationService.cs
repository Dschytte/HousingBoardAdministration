using BookingSystemApi.Application.IRepositories;
using BookingSystemApi.Application.Queris.Resource.GetResourcesQuery;
using BookingSystemApi.Domain.DomainService;

namespace BookingSystemApi.Application.DomainService.Implementering;

public class BookingDateValidationService : IBookingDateValidationService
{
    private readonly IResourceRepository _resourceRepository;

    public BookingDateValidationService(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }

    public bool IsResourceAvailableAsync(Guid resourceId, DateTime startDate, DateTime endDate)
    {
        var existingBookings = _resourceRepository.Get(new GetResourcesQuery { Id = resourceId }).Bookings;

        // Tjek om der er overlappende bookinger
        var isResourceAvailable = !existingBookings.Any(b =>
            (startDate >= b.StartDate && startDate <= b.EndDate) ||
            (endDate <= b.EndDate && endDate >= b.StartDate) ||
            startDate < b.StartDate && endDate > b.EndDate);

        return isResourceAvailable;
    }
}
