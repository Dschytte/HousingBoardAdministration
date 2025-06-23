namespace BookingSystemApi.Application.Commands.Booking.Create
{
    public record CreateBookingCommand : IRequest<bool>
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid BookingOwnerId { get; set; }
        public List<Guid> ResourceIdsList { get; set; }

    }
}
