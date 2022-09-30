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
            long roleId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            RoleId = roleId;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public long RoleId { get; private set; }

        public static UserDto MapFrom(User userEntity)
        {
            return new UserDto(
                userEntity.Id,
                userEntity.Name,
                userEntity.Surname,
                userEntity.Email,
                userEntity.RoleId
                );
        }
    }
}
