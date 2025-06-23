
namespace BookingSystemApi.Domain.DomainService;

public interface IBookingDateValidationService
{
    bool IsResourceAvailableAsync(Guid resourceId, DateTime startDate, DateTime endDate);
}
