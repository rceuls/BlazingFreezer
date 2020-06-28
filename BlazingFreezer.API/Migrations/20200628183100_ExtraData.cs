using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingFreezer.API.Migrations
{
    public partial class ExtraData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Freezers",
                columns: new[] { "FreezerId", "Name" },
                values: new object[] { 2, "Garage" });

            migrationBuilder.InsertData(
                table: "FreezerDrawers",
                columns: new[] { "FreezerDrawerId", "FreezerId", "Name" },
                values: new object[,]
                {
                    { 3, 2, "Schuif 1" },
                    { 4, 2, "Schuif 2" },
                    { 5, 2, "Schuif 3" },
                    { 6, 2, "Schuif 4" },
                    { 7, 2, "Schuif 5" },
                    { 8, 2, "Schuif 6" },
                    { 9, 2, "Schuif 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FreezerDrawers",
                keyColumn: "FreezerDrawerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Freezers",
                keyColumn: "FreezerId",
                keyValue: 2);
        }
    }
}
