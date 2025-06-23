namespace BookingSystemApi.Application.Queris.Resident.GetResident
{
    public record GetResidentQuery : IRequest<GetResidentQueryResult>
    {
        public Guid Id { get; set; }

    }
}
