using Microsoft.EntityFrameworkCore;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess
{
    //Use next command in Package Manager Console to update Dev env DB
    //PM> $env:ASPNETCORE_ENVIRONMENT = 'Debug'; Update-Database
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
