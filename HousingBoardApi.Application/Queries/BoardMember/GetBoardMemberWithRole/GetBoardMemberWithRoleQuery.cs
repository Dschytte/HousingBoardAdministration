

namespace HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;

public record GetBoardMemberWithRoleQuery : IRequest<GetBoardMemberWithRoleQueryResult>
{
    public Guid Id { get; set; }
    public bool IncludeOldRoles { get; set; }
}
