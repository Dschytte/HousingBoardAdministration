namespace HousingBoardApi.Application.Queries.BoardMember.GetAllBoardMembersWithRoles;

public class GetAllBoardMembersWithRolesQueryResult
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public BoardMemberRoleDto BoardMemberCurrentRole { get; set; }
}
