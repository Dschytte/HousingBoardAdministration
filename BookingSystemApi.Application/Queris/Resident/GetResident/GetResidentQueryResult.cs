namespace BookingSystemApi.Application.Queris.Resident.GetResident
{
    public record GetResidentQueryResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentAddress { get; set; }
        public List<BookingDto> Booking { get; set; }

    }
}
