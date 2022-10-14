using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Users.Commands
{
    public class CreateUserCommand
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long RoleId { get; set; }
    }

    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, long>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<long> Handle(CreateUserCommand command)
        {
            var user = new User(
                command.Name,
                command.Surname,
                command.Email,
                command.RoleId
                );

            return await _userRepository.CreateAsync(user);
        }
    }
}
