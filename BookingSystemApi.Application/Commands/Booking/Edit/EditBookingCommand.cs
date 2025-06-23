namespace BookingSystemApi.Application.Commands.Booking.Update
{
    public record EditBookingCommand : IRequest
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
