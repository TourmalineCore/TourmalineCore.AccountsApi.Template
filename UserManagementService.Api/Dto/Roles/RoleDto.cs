namespace UserManagementService.Api.Dto.Roles
{
    public class RoleDto
    {
        public RoleDto(long id, string name, string normalizedName)
        {
            Id = id;
            Name = name;
            NormalizedName = normalizedName;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
