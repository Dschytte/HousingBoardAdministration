
using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Queries.BoardMember.GetAllBoardMembersWithRoles;

public class GetAllBoardMembersWithRolesQueryHandler : IRequestHandler<GetAllBoardMembersWithRolesQuery, List<GetAllBoardMembersWithRolesQueryResult>>
{
    private readonly IBoardMemberRepository _boardMemberRepository;

    public GetAllBoardMembersWithRolesQueryHandler(IBoardMemberRepository boardMemberRepository)
    {
        _boardMemberRepository = boardMemberRepository;
    }

    Task<List<GetAllBoardMembersWithRolesQueryResult>> IRequestHandler<GetAllBoardMembersWithRolesQuery, List<GetAllBoardMembersWithRolesQueryResult>>.Handle(GetAllBoardMembersWithRolesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_boardMemberRepository.GetAll().ToList());
    }
}
