namespace UserManagementService.Api.Dto.Users
{
    public class UserDto
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public long? RoleId { get; private set; }

        public UserDto(long id, string name, string surname, string email, long? roleId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            RoleId = roleId;
        }
    }
}
