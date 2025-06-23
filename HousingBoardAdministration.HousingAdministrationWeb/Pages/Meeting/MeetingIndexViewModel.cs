using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting;

public class MeetingIndexViewModel
{
    public Guid Id { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
    public bool IsDeleted { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public MeetingTypeViewModel MeetingType { get; set; }

    public DateTime MeetingTime { get; set; }
    public string AddressLocation { get; set; }
}
