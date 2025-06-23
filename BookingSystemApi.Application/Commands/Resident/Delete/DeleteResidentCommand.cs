namespace BookingSystemApi.Application.Commands.Resident.Delete
{
    public record DeleteResidentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
