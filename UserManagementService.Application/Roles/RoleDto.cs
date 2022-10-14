using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Roles
{
    public class RoleDto
    {
        public RoleDto(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public static RoleDto MapFrom(Role roleEntity)
        {
            return new RoleDto(roleEntity.Id, roleEntity.Name.ToString());
        }
    }
}
