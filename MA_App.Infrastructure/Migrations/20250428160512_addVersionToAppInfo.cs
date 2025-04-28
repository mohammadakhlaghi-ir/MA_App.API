using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MA_App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addVersionToAppInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Version",
                table: "AppInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "AppInfos");
        }
    }
}
