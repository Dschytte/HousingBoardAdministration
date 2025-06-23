using HousingBoardApi.Application.Commands.BoardMemberRole.Create;
using HousingBoardApi.Application.IRepositories;

namespace HousingBoardApi.Application.Commands.BoardMember.Create
{
    public class CreateBoardMemberCommandHandler : IRequestHandler<CreateBoardMemberCommand>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;
        private readonly IBoardMemberRoleRepository _boardMemberRoleRepository;

        public CreateBoardMemberCommandHandler(IBoardMemberRepository boardMemberRepository, IBoardMemberRoleRepository boardMemberRoleRepository)
        {
            _boardMemberRepository = boardMemberRepository;
            _boardMemberRoleRepository = boardMemberRoleRepository;
        }

        public Task Handle(CreateBoardMemberCommand request, CancellationToken cancellationToken)
        {
            Guid boardMemberCreatedGuid = _boardMemberRepository.Create(request);

            _boardMemberRoleRepository.Add(new CreateBoardMemberRoleCommand
            {
                BoardMemberId = boardMemberCreatedGuid,
                RoleId = request.RoleId
            }); ;

            return Task.CompletedTask;
        }
    }
}
