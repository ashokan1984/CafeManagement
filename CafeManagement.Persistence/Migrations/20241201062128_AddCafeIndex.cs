using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCafeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cafes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Cafes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_Location",
                table: "Cafes",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_Cafes_Name",
                table: "Cafes",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cafes_Location",
                table: "Cafes");

            migrationBuilder.DropIndex(
                name: "IX_Cafes_Name",
                table: "Cafes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cafes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Cafes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
