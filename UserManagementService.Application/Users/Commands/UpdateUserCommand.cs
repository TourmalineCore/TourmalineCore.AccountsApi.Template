using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public class UpdateUserCommand
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        
        public string Email { get; set; }

        public long RoleId { get; set; }
    }

    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request)
        {
            
            var user = await _userRepository.FindByIdAsync(request.Id);

            user.Update(
                request.Name,
                request.Surname,
                request.Email,
                request.RoleId
            );

            await _userRepository.UpdateAsync(user);
        }
    }
}
