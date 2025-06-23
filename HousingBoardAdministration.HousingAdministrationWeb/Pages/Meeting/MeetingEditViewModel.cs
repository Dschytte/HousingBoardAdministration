using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting
{
    public class MeetingEditViewModel
    {
        public Guid Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime MeetingTime { get; set; }
        [Required]
        public string AddressLocation { get; set; }
    }
}
