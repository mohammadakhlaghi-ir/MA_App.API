using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MA_App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initLayouts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemLayoutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLayoutTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Layouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Main = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionLayoutTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLayoutTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LayoutId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MobileVisible = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectionLayoutTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionLayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionLayouts_Layouts_LayoutId",
                        column: x => x.LayoutId,
                        principalTable: "Layouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionLayouts_SectionLayoutTypes_SectionLayoutTypeId",
                        column: x => x.SectionLayoutTypeId,
                        principalTable: "SectionLayoutTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionItemLayouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionLayoutId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MobileVisible = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Modifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemLayoutTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionItemLayouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SectionItemLayouts_ItemLayoutTypes_ItemLayoutTypeId",
                        column: x => x.ItemLayoutTypeId,
                        principalTable: "ItemLayoutTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionItemLayouts_SectionLayouts_SectionLayoutId",
                        column: x => x.SectionLayoutId,
                        principalTable: "SectionLayouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemLayouts_ItemLayoutTypeId",
                table: "SectionItemLayouts",
                column: "ItemLayoutTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionItemLayouts_SectionLayoutId",
                table: "SectionItemLayouts",
                column: "SectionLayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionLayouts_LayoutId",
                table: "SectionLayouts",
                column: "LayoutId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionLayouts_SectionLayoutTypeId",
                table: "SectionLayouts",
                column: "SectionLayoutTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionItemLayouts");

            migrationBuilder.DropTable(
                name: "ItemLayoutTypes");

            migrationBuilder.DropTable(
                name: "SectionLayouts");

            migrationBuilder.DropTable(
                name: "Layouts");

            migrationBuilder.DropTable(
                name: "SectionLayoutTypes");
        }
    }
}
