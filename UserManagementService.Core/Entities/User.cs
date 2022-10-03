namespace UserManagementService.Core.Entities
{
    public class User : IIdentityEntity
    {
        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public long RoleId { get; private set; }

        public Role Role { get; private set; }

        // For DB Context
        private User() { }

        public User(string name, string surname, string email, string password, long roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;

            // ToDo add password hash
            Password = password;
            RoleId = roleId;
        }

        public void Update(string name, string surname, string email, string password, long roleId)
        {
            Name = name;
            Surname = surname;
            Email = email;

            // ToDo add password hash
            Password = password;
            RoleId = roleId;
        }

        public void AddRole(Role role)
        {
            Role = role;
        }
    }
}
