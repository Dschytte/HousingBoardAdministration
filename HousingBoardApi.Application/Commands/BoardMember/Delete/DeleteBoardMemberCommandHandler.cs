using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.BoardMember.Delete
{
    public class DeleteBoardMemberCommandHandler : IRequestHandler<DeleteBoardMemberCommand>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;

        public DeleteBoardMemberCommandHandler(IBoardMemberRepository boardMemberRepository)
        {
            _boardMemberRepository = boardMemberRepository;
        }

        Task IRequestHandler<DeleteBoardMemberCommand>.Handle(DeleteBoardMemberCommand request, CancellationToken cancellationToken)
        {
            _boardMemberRepository.Delete(request);
            return Task.CompletedTask;
        }
    }
}
