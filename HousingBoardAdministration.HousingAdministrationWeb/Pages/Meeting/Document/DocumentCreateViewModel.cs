using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.Meeting.Document;

public record DocumentCreateViewModel
{
    [Required]
    public string Title { get; set; }
    public Guid DocumentTypeId { get; set; }
    [Required]
    public required string DocumentFile { get; set; }
    public Guid MeetingId { get; set; }
    public Guid DocumentOwnerId { get; set; }
}
