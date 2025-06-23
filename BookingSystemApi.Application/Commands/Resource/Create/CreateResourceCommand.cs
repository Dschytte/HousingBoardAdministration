namespace BookingSystemApi.Application.Commands.Resource.Create;
public record CreateResourceCommand : IRequest
{
    public string Description { get; set; }
    public string Specification { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }
}
