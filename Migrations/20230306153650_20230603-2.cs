using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelCompany.Migrations
{
    /// <inheritdoc />
    public partial class _202306032 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_PersonInfo_personInfonationalNumber",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfo",
                table: "PersonInfo");

            migrationBuilder.RenameColumn(
                name: "personInfonationalNumber",
                table: "Booking",
                newName: "personInfouserId");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_personInfonationalNumber",
                table: "Booking",
                newName: "IX_Booking_personInfouserId");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PersonInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nationalNumber",
                table: "PersonInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfo",
                table: "PersonInfo",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_PersonInfo_personInfouserId",
                table: "Booking",
                column: "personInfouserId",
                principalTable: "PersonInfo",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_PersonInfo_personInfouserId",
                table: "Booking");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInfo",
                table: "PersonInfo");

            migrationBuilder.RenameColumn(
                name: "personInfouserId",
                table: "Booking",
                newName: "personInfonationalNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Booking_personInfouserId",
                table: "Booking",
                newName: "IX_Booking_personInfonationalNumber");

            migrationBuilder.AlterColumn<string>(
                name: "nationalNumber",
                table: "PersonInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "PersonInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInfo",
                table: "PersonInfo",
                column: "nationalNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_PersonInfo_personInfonationalNumber",
                table: "Booking",
                column: "personInfonationalNumber",
                principalTable: "PersonInfo",
                principalColumn: "nationalNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
