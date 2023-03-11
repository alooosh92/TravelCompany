using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class _20230223 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "note",
                table: "Booking",
                newName: "noteUser");

            migrationBuilder.AddColumn<string>(
                name: "noteCompany",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "noteCompany",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "noteUser",
                table: "Booking",
                newName: "note");
        }
    }
}
