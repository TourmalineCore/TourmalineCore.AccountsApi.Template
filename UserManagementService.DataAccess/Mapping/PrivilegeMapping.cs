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

            builder.HasData(new Privilege(1, PrivilegesNames.CanManageEverything),
                            new Privilege(2, PrivilegesNames.CanViewEmployeeList),
                            new Privilege(3, PrivilegesNames.CanViewEmployeePage));
        }
    }
}
