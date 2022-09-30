using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Roles.Queries
{
    public partial class GetRoleByIdQuery
    {
        public long Id { get; set; }
    }

    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, Role>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<Role> Handle(GetRoleByIdQuery request)
        {
            return _roleRepository.FindOneAsync(request.Id);
        }
    }
}
