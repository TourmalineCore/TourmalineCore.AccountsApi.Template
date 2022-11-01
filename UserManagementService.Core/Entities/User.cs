using NodaTime;

namespace UserManagementService.Core.Entities
{
    public class User : IIdentityEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public long RoleId { get; private set; }

        public Role Role { get; private set; }
        public Instant? DeletedAtUtc { get; private set; } = null;

        // For DB Context
        private User() { }

        public User(string name, string surname, string email, long roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;

            // ToDo add password hash
            RoleId = roleId;
        }

        public void Update(string name, string surname, string email, long roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;

            // ToDo add password hash
            RoleId = roleId;
        }

        public void AddRole(Role role)
        {
            Role = role;
        }
        public void Delete(Instant deletedAtUtc)
        {
            DeletedAtUtc = deletedAtUtc;
        }
    }
}
