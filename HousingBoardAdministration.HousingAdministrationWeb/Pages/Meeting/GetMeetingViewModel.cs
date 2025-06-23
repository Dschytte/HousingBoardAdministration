using HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting.Document;
using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting;

public record GetMeetingViewModel
{
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<DocumentViewModel>? Documents { get; set; }

    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }
}
