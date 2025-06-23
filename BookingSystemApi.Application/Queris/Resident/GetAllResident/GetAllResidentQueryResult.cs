namespace BookingSystemApi.Application.Queris.Resident.GetAllResident
{
    public record GetAllResidentQueryResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentAddress { get; set; }
    }
}
