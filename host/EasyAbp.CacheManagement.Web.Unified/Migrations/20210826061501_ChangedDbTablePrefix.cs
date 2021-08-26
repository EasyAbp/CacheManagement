using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.CacheManagement.Migrations
{
    public partial class ChangedDbTablePrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CacheManagementCacheItems",
                table: "CacheManagementCacheItems");

            migrationBuilder.RenameTable(
                name: "CacheManagementCacheItems",
                newName: "EasyAbpCacheManagementCacheItems");

            migrationBuilder.AlterColumn<string>(
                name: "Exceptions",
                table: "AbpAuditLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpCacheManagementCacheItems",
                table: "EasyAbpCacheManagementCacheItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpCacheManagementCacheItems",
                table: "EasyAbpCacheManagementCacheItems");

            migrationBuilder.RenameTable(
                name: "EasyAbpCacheManagementCacheItems",
                newName: "CacheManagementCacheItems");

            migrationBuilder.AlterColumn<string>(
                name: "Exceptions",
                table: "AbpAuditLogs",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CacheManagementCacheItems",
                table: "CacheManagementCacheItems",
                column: "Id");
        }
    }
}
