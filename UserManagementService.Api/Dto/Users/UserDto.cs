namespace UserManagementService.Api.Dto.Users
{
    public class UserDto
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public UserDto(string userName, string email, string name, string surname, string patronymic)
        {
            UserName = userName;
            Email = email;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
