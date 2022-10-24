using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;
using NodaTime;

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
            var user = await _userRepository.FindByIdAsync(request.Id);
            user.Delete(
                SystemClock.Instance.GetCurrentInstant().InUtc()
             );
            await _userRepository.UpdateAsync(user);
        }
    }
}
