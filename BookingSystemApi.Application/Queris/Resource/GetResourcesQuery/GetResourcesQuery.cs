namespace BookingSystemApi.Application.Queris.Resource.GetResourcesQuery
{
    public class GetResourcesQuery : IRequest<GetResourcesQueryResult>
    {
        public Guid Id { get; set; }
    }
}
