namespace BookingSystemApi.Application.Commands.Resource.Delete
{
    public class DeleteResourceCommad : IRequest
    {
        public Guid Id { get; set; }
    }
}
