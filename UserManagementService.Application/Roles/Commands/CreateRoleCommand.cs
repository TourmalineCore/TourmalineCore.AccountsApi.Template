using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Entities;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Commands
{
    public partial class CreateRoleCommand : IRequest<long>
    {
        public string Name { get; set; }

        public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, long>
        {
            private readonly IRoleRepository _roleRepository;

            public CreateRoleCommandHandler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            public Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                var role = new Role(request.Name);

                return _roleRepository.CreateAsync(role);
            }
        }
    }
}
