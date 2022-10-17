using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(p => p.Privileges)
                .WithMany(p => p.Roles)
                .UsingEntity(j => j.ToTable("RolePrivileges"));

            builder.Property(x => x.Name)
                .HasConversion<string>();

            builder.HasData(new Role(1, RoleNames.Admin), 
                            new Role(2, RoleNames.Seo), 
                            new Role(3, RoleNames.Employee));
        }
    }
}
