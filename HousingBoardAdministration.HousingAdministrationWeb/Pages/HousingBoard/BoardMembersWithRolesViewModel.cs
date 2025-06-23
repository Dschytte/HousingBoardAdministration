namespace HousingBoardAdministration.HousingAdministrationWeb.Pages.HousingBoard;

public class BoardMembersWithRolesViewModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public BoardMemberRoleDto BoardMemberCurrentRole { get; set; }
}
