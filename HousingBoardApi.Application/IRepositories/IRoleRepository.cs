using HousingBoardApi.Application.Queries.Role.Dto;

namespace HousingBoardApi.Application.IRepositories
{
    public interface IRoleRepository
    {
        RoleGetQueryResultDto Get(Guid id);
        IEnumerable<RoleGetAllQueryResultDto> GetAll();
    }
}
