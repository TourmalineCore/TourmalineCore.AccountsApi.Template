using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Roles.Queries
{
    public partial class GetRoleByIdQuery : IRequest<Role>
    {
        public long Id { get; set; }

        public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, Role>
        {
            private readonly IRoleRepository _roleRepository;

            public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            public Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
            {
                return _roleRepository.FindOneAsync(request.Id);
            }
        }
    }
}
