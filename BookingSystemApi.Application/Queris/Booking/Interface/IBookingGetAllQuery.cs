using BookingSystemApi.Application.Queris.Booking.Dto;

namespace BookingSystemApi.Application.Queris.Booking.Interface
{
    public interface IBookingGetAllQuery
    {
        IEnumerable<BookingGetAllQueryResultDto> GetAll(Guid userId);
    }
}
