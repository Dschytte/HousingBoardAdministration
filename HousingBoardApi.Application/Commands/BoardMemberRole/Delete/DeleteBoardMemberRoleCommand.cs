namespace HousingBoardApi.Application.Commands.BoardMemberRole.Delete;

public record DeleteBoardMemberRoleCommand : IRequest
{
    public Guid BoardMemberId { get; set; }
    public Guid RoleId { get; set; }

}
