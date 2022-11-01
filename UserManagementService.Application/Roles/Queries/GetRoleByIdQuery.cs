using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;
using UserManagementService.DataAccess.Respositories;

namespace UserManagementService.Application.Roles.Queries
{
    public class GetRoleByIdQuery
    {
        public long Id { get; set; }
    }

    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request)
        {
            var roleEntity = await _roleRepository.FindByIdAsync(request.Id);

            return new RoleDto(roleEntity.Id, roleEntity.Name.ToString());
        }
    }
}
