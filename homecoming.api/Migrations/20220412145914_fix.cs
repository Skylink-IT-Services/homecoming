using Microsoft.EntityFrameworkCore.Migrations;

namespace homecoming.api.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Rooms_RoomId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RoomId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RoomId",
                table: "Reviews",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Rooms_RoomId",
                table: "Reviews",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId");
        }
    }
}
