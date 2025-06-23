using HousingBoardApi.Application.IRepositories;
namespace HousingBoardApi.Application.Commands.BoardMember.Edit;

public class EditBoardMemberCommandHandler : IRequestHandler<EditBoardMemberCommand>
{
    private readonly IBoardMemberRepository _boardMemberRepository;

    public EditBoardMemberCommandHandler(IBoardMemberRepository boardMemberRepository)
    {
        _boardMemberRepository = boardMemberRepository;
    }

    Task IRequestHandler<EditBoardMemberCommand>.Handle(EditBoardMemberCommand request, CancellationToken cancellationToken)
    {

        //read
        var model = _boardMemberRepository.Load(request.Id);

        //doit 
        model.Edit(request.FirstName, request.LastName, request.ResidentAddress, request.RowVersion);
        //save
        _boardMemberRepository.Update(model);

        return Task.CompletedTask;
    }
}
