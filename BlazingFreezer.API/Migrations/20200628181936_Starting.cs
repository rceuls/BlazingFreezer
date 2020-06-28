using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlazingFreezer.API.Migrations
{
    public partial class Starting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Freezers",
                columns: table => new
                {
                    FreezerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freezers", x => x.FreezerId);
                });

            migrationBuilder.CreateTable(
                name: "FreezerDrawers",
                columns: table => new
                {
                    FreezerDrawerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FreezerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreezerDrawers", x => x.FreezerDrawerId);
                    table.ForeignKey(
                        name: "FK_FreezerDrawers_Freezers_FreezerId",
                        column: x => x.FreezerId,
                        principalTable: "Freezers",
                        principalColumn: "FreezerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreezerItems",
                columns: table => new
                {
                    FreezerItemId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FreezerDrawerId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Since = table.Column<DateTime>(nullable: false),
                    IsVacuum = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreezerItems", x => x.FreezerItemId);
                    table.ForeignKey(
                        name: "FK_FreezerItems_FreezerDrawers_FreezerDrawerId",
                        column: x => x.FreezerDrawerId,
                        principalTable: "FreezerDrawers",
                        principalColumn: "FreezerDrawerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Freezers",
                columns: new[] { "FreezerId", "Name" },
                values: new object[] { 1, "Keuken" });

            migrationBuilder.InsertData(
                table: "FreezerDrawers",
                columns: new[] { "FreezerDrawerId", "FreezerId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Bovenaan" },
                    { 2, 1, "Onderaan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreezerDrawers_FreezerId",
                table: "FreezerDrawers",
                column: "FreezerId");

            migrationBuilder.CreateIndex(
                name: "IX_FreezerItems_FreezerDrawerId",
                table: "FreezerItems",
                column: "FreezerDrawerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreezerItems");

            migrationBuilder.DropTable(
                name: "FreezerDrawers");

            migrationBuilder.DropTable(
                name: "Freezers");
        }
    }
}
