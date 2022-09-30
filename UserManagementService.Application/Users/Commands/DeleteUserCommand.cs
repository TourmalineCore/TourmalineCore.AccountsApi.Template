using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public class DeleteUserCommand
    {
        public long Id { get; set; }
    }

    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand request)
        {
            var user = await _userRepository.FindOneAsync(request.Id);

            await _userRepository.RemoveAsync(user);
        }
    }
}
