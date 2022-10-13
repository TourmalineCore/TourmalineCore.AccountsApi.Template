using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Mapping
{
    public class PrivilegeMapping : IEntityTypeConfiguration<Privilege>
    {
        public void Configure(EntityTypeBuilder<Privilege> builder)
        {
            builder.Property(x => x.Name)
                   .HasConversion<string>();
        }
    }
}
