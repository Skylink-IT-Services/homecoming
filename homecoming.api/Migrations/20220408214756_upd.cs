using Microsoft.EntityFrameworkCore.Migrations;

namespace homecoming.api.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "Check_Out_Date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Bookings",
                newName: "Check_In_Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Check_Out_Date",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Check_In_Date",
                table: "Bookings",
                newName: "EndDate");
        }
    }
}
