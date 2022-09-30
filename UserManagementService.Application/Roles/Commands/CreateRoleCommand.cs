using System.Threading.Tasks;
using UserManagementService.Core.Entities;
using UserManagementService.Core.Contracts;
using UserManagementService.Application.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class CreateRoleCommand
    {
        public string Name { get; set; }
    }

    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, long>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<long> Handle(CreateRoleCommand request)
        {
            var role = new Role(request.Name);

            return _roleRepository.CreateAsync(role);
        }
    }
}
