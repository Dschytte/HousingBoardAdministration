using HousingBoardApi.Application.Queries.Role.Dto;

namespace HousingBoardApi.Application.Queries.Role.Interface;

public interface IRoleGetAllQuery
{
    IEnumerable<RoleGetAllQueryResultDto> GetAll();
}
