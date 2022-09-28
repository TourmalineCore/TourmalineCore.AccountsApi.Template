namespace UserManagementService.Core.Entities
{
    public class UserRole
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long RoleId { get; set; }

        public Role Role { get; set; }
    }
}
