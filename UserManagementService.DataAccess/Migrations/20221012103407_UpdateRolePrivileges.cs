using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UserManagementService.DataAccess.Migrations
{
    public partial class UpdateRolePrivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePriveleges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Privileges",
                table: "Privileges");

            migrationBuilder.RenameTable(
                name: "Privileges",
                newName: "Privilege");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Privilege",
                table: "Privilege",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                columns: table => new
                {
                    PrivilegesId = table.Column<long>(type: "bigint", nullable: false),
                    RolesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivileges", x => new { x.PrivilegesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Privilege_PrivilegesId",
                        column: x => x.PrivilegesId,
                        principalTable: "Privilege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePrivileges_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePrivileges_RolesId",
                table: "RolePrivileges",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Privilege",
                table: "Privilege");

            migrationBuilder.RenameTable(
                name: "Privilege",
                newName: "Privileges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Privileges",
                table: "Privileges",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RolePriveleges",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrivilegeId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePriveleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePriveleges_Privileges_PrivilegeId",
                        column: x => x.PrivilegeId,
                        principalTable: "Privileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePriveleges_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePriveleges_PrivilegeId",
                table: "RolePriveleges",
                column: "PrivilegeId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePriveleges_RoleId",
                table: "RolePriveleges",
                column: "RoleId");
        }
    }
}
