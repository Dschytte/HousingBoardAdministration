

using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.BoardMemberRole.Delete;

public class DeleteBoardMemberRoleCommandHandler : IRequestHandler<DeleteBoardMemberRoleCommand>
{
    private readonly IBoardMemberRoleRepository _boardMemberRoleRepository;

    public DeleteBoardMemberRoleCommandHandler(IBoardMemberRoleRepository boardMemberRoleRepository)
    {
        _boardMemberRoleRepository = boardMemberRoleRepository;
    }
    Task IRequestHandler<DeleteBoardMemberRoleCommand>.Handle(DeleteBoardMemberRoleCommand request, CancellationToken cancellationToken)
    {
        _boardMemberRoleRepository.Delete(request);
        return Task.CompletedTask;
    }
}
