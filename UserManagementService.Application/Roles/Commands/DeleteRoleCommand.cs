using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public class DeleteRoleCommand
    {
        public long Id { get; set; }
    }

    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task Handle(DeleteRoleCommand request)
        {
            var privilege = await _roleRepository.FindByIdAsync(request.Id);

            await _roleRepository.RemoveAsync(privilege);
        }
    }
}
