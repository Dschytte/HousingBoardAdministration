
using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;

public class GetBoardMemberWithRoleQueryResult
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ResidentAddress { get; set; }
    public List<BoardMemberRoleDto> BoardMemberRoles { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}
