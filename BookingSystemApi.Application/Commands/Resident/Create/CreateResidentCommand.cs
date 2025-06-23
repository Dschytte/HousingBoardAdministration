namespace BookingSystemApi.Application.Commands.Resident.Create
{
    public record CreateResidentCommand : IRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentAddress { get; set; }
        public Guid UserId { get; set; }


    }
}
