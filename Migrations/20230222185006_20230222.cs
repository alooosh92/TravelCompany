using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class _20230222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "busNumber",
                table: "Buses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "busNumber",
                table: "Buses");
        }
    }
}
