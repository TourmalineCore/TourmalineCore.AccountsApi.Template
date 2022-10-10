namespace UserManagementService.Core.Entities
{
    public class RolePriveleges
    {
        public long Id { get; private set; }

        public long RoleId { get; private set; }

        public Role Role { get; private set; }

        public long PrivilegeId { get; private set; }

        public Privilege Privilege { get; private set; }
    }
}
