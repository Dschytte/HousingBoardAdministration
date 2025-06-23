namespace HousingBoardApi.Application.Messages.Events
{
    public class CreateMeetingEmailEvent : INotification
    {
        public string Title { get; set; }
        public string AddressLocation { get; set; }
        public DateTime MeetingTime { get; set; }

    }
}
