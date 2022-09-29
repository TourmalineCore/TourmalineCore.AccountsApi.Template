using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public partial class UpdateUserCommand : IRequest
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public long RoleId { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
        {
            private readonly IUserRepository _userRepository;

            public UpdateUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.FindOneAsync(request.Id);

                user.Update(request.UserName,
                    request.Email,
                    request.Name,
                    request.Surname,
                    request.Patronymic,
                    request.RoleId
                );

                await _userRepository.UpdateAsync(user);

                return Unit.Value;
            }
        }
    }
}
