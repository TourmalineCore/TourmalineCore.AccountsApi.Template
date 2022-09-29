using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Roles.Queries
{
    public class GetRoleListQuery : IRequest<IEnumerable<Role>>
    {
        public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, IEnumerable<Role>>
        {
            private readonly IRoleRepository _roleRepository;

            public GetRoleListQueryHandler(IRoleRepository roleRepository)
            {
                _roleRepository = roleRepository;
            }

            public Task<IEnumerable<Role>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
            {
                return _roleRepository.GetAllAsync();
            }
        }
    }
}
