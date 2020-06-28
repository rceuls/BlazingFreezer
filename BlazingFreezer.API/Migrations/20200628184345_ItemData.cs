using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingFreezer.API.Migrations
{
    public partial class ItemData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreezerDrawers_Freezers_FreezerId",
                table: "FreezerDrawers");

            migrationBuilder.DropForeignKey(
                name: "FK_FreezerItems_FreezerDrawers_FreezerDrawerId",
                table: "FreezerItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreezerItems",
                table: "FreezerItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreezerDrawers",
                table: "FreezerDrawers");

            migrationBuilder.RenameTable(
                name: "FreezerItems",
                newName: "FreezerItem");

            migrationBuilder.RenameTable(
                name: "FreezerDrawers",
                newName: "FreezerDrawer");

            migrationBuilder.RenameIndex(
                name: "IX_FreezerItems_FreezerDrawerId",
                table: "FreezerItem",
                newName: "IX_FreezerItem_FreezerDrawerId");

            migrationBuilder.RenameIndex(
                name: "IX_FreezerDrawers_FreezerId",
                table: "FreezerDrawer",
                newName: "IX_FreezerDrawer_FreezerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreezerItem",
                table: "FreezerItem",
                column: "FreezerItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreezerDrawer",
                table: "FreezerDrawer",
                column: "FreezerDrawerId");

            migrationBuilder.InsertData(
                table: "FreezerItem",
                columns: new[] { "FreezerItemId", "FreezerDrawerId", "IsVacuum", "Name", "Since" },
                values: new object[,]
                {
                    { 1, 1, true, "potato", new DateTime(2020, 6, 18, 20, 43, 44, 862, DateTimeKind.Local).AddTicks(2492) },
                    { 2, 1, true, "sausage", new DateTime(2020, 6, 18, 20, 43, 44, 866, DateTimeKind.Local).AddTicks(6956) },
                    { 3, 3, false, "spaghetti batch 1", new DateTime(2020, 6, 23, 20, 43, 44, 866, DateTimeKind.Local).AddTicks(7070) },
                    { 4, 3, false, "spaghetti batch 2", new DateTime(2020, 6, 23, 20, 43, 44, 866, DateTimeKind.Local).AddTicks(7101) },
                    { 5, 3, false, "spaghetti batch 3", new DateTime(2020, 6, 23, 20, 43, 44, 866, DateTimeKind.Local).AddTicks(7127) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FreezerDrawer_Freezers_FreezerId",
                table: "FreezerDrawer",
                column: "FreezerId",
                principalTable: "Freezers",
                principalColumn: "FreezerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreezerItem_FreezerDrawer_FreezerDrawerId",
                table: "FreezerItem",
                column: "FreezerDrawerId",
                principalTable: "FreezerDrawer",
                principalColumn: "FreezerDrawerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FreezerDrawer_Freezers_FreezerId",
                table: "FreezerDrawer");

            migrationBuilder.DropForeignKey(
                name: "FK_FreezerItem_FreezerDrawer_FreezerDrawerId",
                table: "FreezerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreezerItem",
                table: "FreezerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FreezerDrawer",
                table: "FreezerDrawer");

            migrationBuilder.DeleteData(
                table: "FreezerItem",
                keyColumn: "FreezerItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FreezerItem",
                keyColumn: "FreezerItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FreezerItem",
                keyColumn: "FreezerItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FreezerItem",
                keyColumn: "FreezerItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FreezerItem",
                keyColumn: "FreezerItemId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "FreezerItem",
                newName: "FreezerItems");

            migrationBuilder.RenameTable(
                name: "FreezerDrawer",
                newName: "FreezerDrawers");

            migrationBuilder.RenameIndex(
                name: "IX_FreezerItem_FreezerDrawerId",
                table: "FreezerItems",
                newName: "IX_FreezerItems_FreezerDrawerId");

            migrationBuilder.RenameIndex(
                name: "IX_FreezerDrawer_FreezerId",
                table: "FreezerDrawers",
                newName: "IX_FreezerDrawers_FreezerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreezerItems",
                table: "FreezerItems",
                column: "FreezerItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FreezerDrawers",
                table: "FreezerDrawers",
                column: "FreezerDrawerId");

            migrationBuilder.AddForeignKey(
                name: "FK_FreezerDrawers_Freezers_FreezerId",
                table: "FreezerDrawers",
                column: "FreezerId",
                principalTable: "Freezers",
                principalColumn: "FreezerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FreezerItems_FreezerDrawers_FreezerDrawerId",
                table: "FreezerItems",
                column: "FreezerDrawerId",
                principalTable: "FreezerDrawers",
                principalColumn: "FreezerDrawerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
