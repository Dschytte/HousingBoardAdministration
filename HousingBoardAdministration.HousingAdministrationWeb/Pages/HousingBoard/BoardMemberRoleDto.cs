

namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard;

public record BoardMemberRoleDto
{
    public RoleDto Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

}
