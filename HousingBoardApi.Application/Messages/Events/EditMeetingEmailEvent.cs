namespace HousingBoardApi.Application.Messages.Events
{
    public class EditMeetingEmailEvent : INotification
    {
        public string Title { get; set; }
        public string AddressLocation { get; set; }
        public DateTime MeetingTime { get; set; }
    }
}
