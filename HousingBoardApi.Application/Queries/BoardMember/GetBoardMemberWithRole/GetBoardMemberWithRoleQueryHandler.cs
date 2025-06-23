

using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;

public class GetBoardMemberWithRoleQueryHandler : IRequestHandler<GetBoardMemberWithRoleQuery, GetBoardMemberWithRoleQueryResult>
{
    private readonly IBoardMemberRepository _boardMemberRepository;

    public GetBoardMemberWithRoleQueryHandler(IBoardMemberRepository boardMemberRepository)
    {
        _boardMemberRepository = boardMemberRepository;
    }

    Task<GetBoardMemberWithRoleQueryResult> IRequestHandler<GetBoardMemberWithRoleQuery, GetBoardMemberWithRoleQueryResult>.Handle(GetBoardMemberWithRoleQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_boardMemberRepository.Get(request));
    }
}
