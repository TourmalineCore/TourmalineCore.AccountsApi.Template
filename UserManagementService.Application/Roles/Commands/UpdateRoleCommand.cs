using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class UpdateRoleCommand : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
        {
            private readonly IRoleRepository _roleRepository;

            public UpdateRoleCommandHandler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                var role = await _roleRepository.FindOneAsync(request.Id);

                role.Update(request.Name);

                await _roleRepository.UpdateAsync(role);

                return Unit.Value;
            }
        }
    }
}
