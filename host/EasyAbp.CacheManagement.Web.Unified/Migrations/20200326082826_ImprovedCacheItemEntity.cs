using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.CacheManagement.Migrations
{
    public partial class ImprovedCacheItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullTypeName",
                table: "CacheManagementCacheItems");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CacheManagementCacheItems",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CacheName",
                table: "CacheManagementCacheItems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IgnoreMultiTenancy",
                table: "CacheManagementCacheItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CacheName",
                table: "CacheManagementCacheItems");

            migrationBuilder.DropColumn(
                name: "IgnoreMultiTenancy",
                table: "CacheManagementCacheItems");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CacheManagementCacheItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "FullTypeName",
                table: "CacheManagementCacheItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
