using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Users.Commands
{
    public partial class DeleteUserCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepository _userRepository;

            public DeleteUserCommandHandler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.FindOneAsync(request.Id);

                await _userRepository.RemoveAsync(user);

                return Unit.Value;
            }
        }
    }
}
