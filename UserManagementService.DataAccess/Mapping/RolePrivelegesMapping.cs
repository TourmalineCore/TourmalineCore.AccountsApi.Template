using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagementService.Core.Entities;

namespace UserManagementService.DataAccess.Mapping
{
    public class RolePrivelegesMapping : IEntityTypeConfiguration<RolePriveleges>
    {
        public void Configure(EntityTypeBuilder<RolePriveleges> builder)
        {
            builder.HasOne(x => x.Role)
                .WithMany(x => x.RolePriveleges);
        }
    }
}
