namespace HousingBoardApi.Application.Commands.BoardMemberRole.Create
{
    public record CreateBoardMemberRoleCommand : IRequest
    {
        public Guid RoleId { get; set; }
        public Guid BoardMemberId { get; set; }
    }
}
