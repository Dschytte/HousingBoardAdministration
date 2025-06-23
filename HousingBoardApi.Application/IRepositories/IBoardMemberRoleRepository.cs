using HousingBoardApi.Application.Commands.BoardMemberRole.Create;
using HousingBoardApi.Application.Commands.BoardMemberRole.Delete;

namespace HousingBoardApi.Application.IRepositories;

public interface IBoardMemberRoleRepository
{
    void Delete(DeleteBoardMemberRoleCommand request);
    void Add(CreateBoardMemberRoleCommand request);
}
