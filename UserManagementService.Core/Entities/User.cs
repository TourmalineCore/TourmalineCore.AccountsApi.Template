using Microsoft.AspNetCore.Identity;

namespace UserManagementService.Core.Entities
{
    public class User : IdentityUser<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public User()
        {

        }

        public User(string userName, string email, string password, string name, string surname, string patronymic)
        {
            UserName = userName;
            Email = email;
            
            // ToDo add password hash
            PasswordHash = password;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
