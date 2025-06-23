using HousingBoardApi.Application.Queries.Role.Dto;

namespace HousingBoardApi.Application.Queries.Role.Interface;

public interface IRoleGetQuery
{
    RoleGetQueryResultDto Get(Guid id);
}
