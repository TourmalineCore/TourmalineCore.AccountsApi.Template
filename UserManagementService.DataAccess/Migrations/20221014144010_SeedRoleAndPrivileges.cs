using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementService.DataAccess.Migrations
{
    public partial class SeedRoleAndPrivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Privilege",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "CanManageEverything" },
                    { 2L, "CanViewEmployeeList" },
                    { 3L, "CanViewEmployeePage" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "Admin", "admin" },
                    { 2L, "Seo", "seo" },
                    { 3L, "Employee", "employee" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Privilege",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
