using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Queries.Role.Dto;
using HousingBoardApi.Application.Queries.Role.Interface;


namespace HousingBoardApi.Application.Queries.Role.Implementation
{
    public class RoleGetQuery : IRoleGetQuery
    {
        private readonly IRoleRepository _roleRepository;

        public RoleGetQuery(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        RoleGetQueryResultDto IRoleGetQuery.Get(Guid id)
        {
            return _roleRepository.Get(id);
        }
    }
}
