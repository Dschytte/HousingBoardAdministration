using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard.BoardMember;

public record BoardMemberEditViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}