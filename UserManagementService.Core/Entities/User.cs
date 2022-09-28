using Microsoft.AspNetCore.Identity;
using UserManagementService.Core.Interfaces;
using System.Collections.Generic;

namespace UserManagementService.Core.Entities
{
    public class User : IdentityUser<long>, IIdentityEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }

        // For DB Context
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

        public void Update(string userName, string email, string name, string surname, string patronymic)
        {
            UserName = userName;
            Email = email;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }
    }
}
