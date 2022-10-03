namespace UserManagementService.Api.Dto.Roles
{
    public class RoleDto
    {
        public RoleDto(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
