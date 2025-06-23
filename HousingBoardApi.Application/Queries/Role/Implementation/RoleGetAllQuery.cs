using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Queries.Role.Dto;
using HousingBoardApi.Application.Queries.Role.Interface;

namespace HousingBoardApi.Application.Queries.Role.Implementation
{
    public class RoleGetAllQuery : IRoleGetAllQuery
    {
        private readonly IRoleRepository _roleRepository;

        public RoleGetAllQuery(IRoleRepository roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        IEnumerable<RoleGetAllQueryResultDto> IRoleGetAllQuery.GetAll()
        {
            return _roleRepository.GetAll();
        }
    }
}
