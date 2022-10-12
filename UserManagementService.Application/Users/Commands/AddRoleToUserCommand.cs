using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public class AddRoleToUserCommand
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }
    }

    public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AddRoleToUserCommandHandler(
            IUserRepository userRepository, 
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task Handle(AddRoleToUserCommand command)
        {
            var user = await _userRepository.FindByIdAsync(command.UserId);
            var role = await _roleRepository.FindByIdAsync(command.RoleId);

            await _userRepository.AddRoleAsync(user, role);
        }
    }
}
