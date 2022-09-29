namespace UserManagementService.Api.Dto.Users
{
    public class UserDto
    {
        public long Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public UserDto(long id, string userName, string email, string name, string surname, string patronymic)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
