namespace BookingSystemApi.Application.Commands.Booking.Delete
{
    public record DeleteBookingCommand : IRequest
    {
        public Guid Id { get; set; }


    }
}
