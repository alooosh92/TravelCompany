using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class _20230603 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "PersonInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "PersonInfo");
        }
    }
}
