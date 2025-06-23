namespace BookingSystemApi.Application.Queris.Resident.GetAllResident
{
    public record GetAllResidentQuery : IRequest<List<GetAllResidentQueryResult>>
    {
        public Guid Id { get; set; }
    }
}
