using Microsoft.EntityFrameworkCore;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess
{
    public class ReadDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ReadDbContext()
        {
            Database.EnsureCreated();
        }

        public ReadDbContext(DbContextOptions<ReadDbContext> options): base(options)
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
