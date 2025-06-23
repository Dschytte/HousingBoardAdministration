using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting;

public record MeetingCreateViewModel
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public DateTime MeetingTime { get; set; }
    [Required]
    public string AddressLocation { get; set; }

    public Guid MeetingTypeId { get; set; }
    public Guid MeetingOwnerId { get; set; }
}
