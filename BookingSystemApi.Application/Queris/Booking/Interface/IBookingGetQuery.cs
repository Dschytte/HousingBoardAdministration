using BookingSystemApi.Application.Queris.Booking.Dto;

namespace BookingSystemApi.Application.Queris.Booking.Interface
{
    public interface IBookingGetQuery
    {
        BookingGetQueryResultDto Get(Guid id);
    }
}
