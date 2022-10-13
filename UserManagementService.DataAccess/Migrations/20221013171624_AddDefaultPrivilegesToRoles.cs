using Microsoft.EntityFrameworkCore.Migrations;
using UserManagementService.Core.Entities;

#nullable disable

namespace UserManagementService.DataAccess.Migrations
{
    public partial class AddDefaultPrivilegesToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "RolePrivileges",
              columns: new[] { "PrivilegesId", "RolesId" },
              values: new object[,]
              {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
