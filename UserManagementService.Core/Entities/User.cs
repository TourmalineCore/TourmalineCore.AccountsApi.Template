using Microsoft.AspNetCore.Identity;
using System;
using UserManagementService.Core.Interfaces;

namespace UserManagementService.Core.Entities
{
    public class User : IdentityUser<long>, IIdentityEntity
    {
        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public long? RoleId { get; private set; }

        public Role? Role { get; private set; }

        // For DB Context
        private User() { }

        public User(string userName, string email, string password, string name, string surname, string patronymic, long roleId)
        {
            UserName = userName;
            Email = email;
            
            // ToDo add password hash
            PasswordHash = password;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            RoleId = roleId;
        }

        public void Update(string userName, string email, string name, string surname, string patronymic, long roleId)
        {
            UserName = userName;
            Email = email;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            RoleId = roleId;
        }

        public void AddRole(Role role)
        {
            Role = role;
        }
    }
}
