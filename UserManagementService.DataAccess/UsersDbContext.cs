using Microsoft.EntityFrameworkCore;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options): base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
