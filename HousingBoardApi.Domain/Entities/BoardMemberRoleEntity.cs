using System.ComponentModel.DataAnnotations;

namespace HousingBoardApi.Domain.Entities;

public class BoardMemberRoleEntity
{
    public BoardMemberRoleEntity() { }

    public Guid Id { get; set; }

    public RoleEntity Role { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    public BoardMemberEntity BoardMember { get; set; }
}
