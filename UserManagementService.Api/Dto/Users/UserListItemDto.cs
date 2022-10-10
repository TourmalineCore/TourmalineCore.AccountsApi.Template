namespace UserManagementService.Api.Dto.Users
{
    public class UserListItemDto
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public string RoleName { get; private set; }

        public UserListItemDto(long id, string name, string surname, string email, string roleName)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            RoleName = roleName;
        }
    }
}
