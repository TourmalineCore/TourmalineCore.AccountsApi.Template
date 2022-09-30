using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Roles.Queries
{
    public class GetRoleListQuery
    {
    }

    public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, IEnumerable<Role>>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleListQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<IEnumerable<Role>> Handle(GetRoleListQuery request)
        {
            return _roleRepository.GetAllAsync();
        }
    }
}
