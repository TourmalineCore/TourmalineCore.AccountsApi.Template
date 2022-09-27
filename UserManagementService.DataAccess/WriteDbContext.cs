using Microsoft.EntityFrameworkCore;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess
{
    public class WriteDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public WriteDbContext()
        {
            Database.EnsureCreated();
        }

        public WriteDbContext(DbContextOptions<WriteDbContext> options): base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
