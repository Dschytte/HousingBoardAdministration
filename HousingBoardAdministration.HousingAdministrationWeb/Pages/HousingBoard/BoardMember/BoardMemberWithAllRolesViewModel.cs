using System.ComponentModel.DataAnnotations;

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard.BoardMember;

public class BoardMemberWithAllRolesViewModel
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public List<BoardMemberRoleDto>? BoardMemberRoles { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}
