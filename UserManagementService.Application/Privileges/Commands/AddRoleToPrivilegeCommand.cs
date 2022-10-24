using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Privileges.Commands
{
    public class AddRoleToPrivilegeCommand
    {
        public long RoleId { get; set; }

        public long PrivilegeId { get; set; }
    }

    public class AddRoleToPrivilegeCommandHandler : ICommandHandler<AddRoleToPrivilegeCommand>
    {
        private readonly IPrivilegeRepository _privilegeRepository;
        private readonly IRoleRepository _roleRepository;

        public AddRoleToPrivilegeCommandHandler(
            IPrivilegeRepository privilegeRepository,
            IRoleRepository roleRepository)
        {
            _privilegeRepository = privilegeRepository;
            _roleRepository = roleRepository;
        }

        public async Task Handle(AddRoleToPrivilegeCommand command)
        {
            var privilege = await _privilegeRepository.FindByIdAsync(command.RoleId);
            var role = await _roleRepository.FindByIdAsync(command.RoleId);

            await _privilegeRepository.AddRoleAsync(privilege, role);
        }
    }
}
