using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class DeleteRoleCommand : IRequest
    {
        public long Id { get; set; }

        public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
        {
            private readonly IRoleRepository _roleRepository;

            public DeleteRoleCommandHandler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                var role = await _roleRepository.FindOneAsync(request.Id);

                await _roleRepository.RemoveAsync(role);

                return Unit.Value;
            }
        }
    }
}
