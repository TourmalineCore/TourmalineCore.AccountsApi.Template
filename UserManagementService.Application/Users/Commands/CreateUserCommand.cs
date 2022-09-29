using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Entities;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public partial class CreateUserCommand : IRequest<long>
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public long RoleId { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
        {
            private readonly IUserRepository _userRepository;

            public CreateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User(
                    request.UserName,
                    request.Email,
                    request.Password,
                    request.Name,
                    request.Surname,
                    request.Patronymic,
                    request.RoleId
                    );

                return await _userRepository.CreateAsync(user);
            }
        }
    }
}
