using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Queries
{
    public class GetRoleListQuery
    {
    }

    public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleListQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetRoleListQuery request)
        {
            var roleEntities = await _roleRepository.GetAllAsync();

            return roleEntities.Select(x => new RoleDto(x.Id, x.Name.ToString()));
        }
    }
}
