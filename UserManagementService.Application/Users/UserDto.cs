using System.Collections.Generic;
using System.Linq;
using UserManagementService.Core.Entities;

namespace UserManagementService.Application.Users
{
    public class UserDto
    {
        public UserDto(
            long id,
            string name,
            string surname,
            string email,
            string roleName,
            IEnumerable<string> privileges)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            RoleName = roleName;
            Privileges = privileges;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public string RoleName { get; private set; }
        
        public IEnumerable<string> Privileges { get; private set; }

        public static UserDto MapFrom(User userEntity)
        {
            var userPrivileges = userEntity.Role.RolePriveleges.Select(x => x.Privilege.Name).Select(n => n.ToString());

            return new UserDto(
                userEntity.Id,
                userEntity.Name,
                userEntity.Surname,
                userEntity.Email,
                userEntity.Role.Name,
                userPrivileges
                );
        }
    }
}
