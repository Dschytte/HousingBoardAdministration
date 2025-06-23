using HousingBoardApi.Application.Commands.BoardMember.Create;
using HousingBoardApi.Application.Commands.BoardMember.Delete;
using HousingBoardApi.Application.Queries.BoardMember.GetAllBoardMembersWithRoles;
using HousingBoardApi.Application.Queries.BoardMember.GetBoardMemberWithRole;

namespace HousingBoardApi.Application.IRepositories
{
    public interface IBoardMemberRepository
    {
        void Delete(DeleteBoardMemberCommand request);
        Guid Create(CreateBoardMemberCommand request);

        BoardMemberEntity Load(Guid id);

        void Update(BoardMemberEntity request);
        IEnumerable<GetAllBoardMembersWithRolesQueryResult> GetAll();
        GetBoardMemberWithRoleQueryResult Get(GetBoardMemberWithRoleQuery request);
    }
}
