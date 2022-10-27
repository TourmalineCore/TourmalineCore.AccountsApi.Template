using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Roles.Commands
{
    public class AddPrivilegeCommand
    {
        public long RoleId { get; set; }
        public List<long> PrivilegeId { get; set; }
    }

    public class AddPrivilegeCommandHandler : ICommandHandler<AddPrivilegeCommand>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPrivilegeRepository _privilegeRepository;

        public AddPrivilegeCommandHandler(IRoleRepository roleRepository, IPrivilegeRepository privilegeRepository)
        {
            _roleRepository = roleRepository;
            _privilegeRepository = privilegeRepository;
        }

        public async Task Handle(AddPrivilegeCommand request)
        {
            var role = await _roleRepository.FindByIdAsync(request.RoleId);
            List<Privilege> privileges = new List<Privilege>();
            foreach (var x in request.PrivilegeId)
            {
                privileges.Add(await _privilegeRepository.FindByIdAsync(x));
            }

            await _roleRepository.UpdateRoleAsync(role, privileges);
        }
    }
}
