using System.Threading.Tasks;
using UserManagementService.Application.Contracts;
using UserManagementService.Core.Contracts;

namespace UserManagementService.Application.Roles.Queries
{
    public partial class GetRoleByIdQuery
    {
        public long Id { get; set; }
    }

    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request)
        {
            var roleEntity = await _roleRepository.FindOneAsync(request.Id);

            return new RoleDto(roleEntity.Id, roleEntity.Name);
        }
    }
}
