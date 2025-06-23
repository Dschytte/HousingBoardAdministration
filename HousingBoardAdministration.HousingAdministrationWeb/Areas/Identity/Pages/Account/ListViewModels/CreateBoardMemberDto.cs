namespace HousingBoardAdministration.HousingAdministrationWeb.Areas.Identity.Pages.Account.ListViewModels;

public record CreateBoardMemberDto
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public Guid RoleId { get; set; }
    public Guid UserId { get; set; }
}
