using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gourmand.Migrations
{
    /// <inheritdoc />
    public partial class INIT2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForgotPasswordCode",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForgotPasswordCode",
                table: "Courier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ForgotPasswordCode",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForgotPasswordCode",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ForgotPasswordCode",
                table: "Courier");

            migrationBuilder.DropColumn(
                name: "ForgotPasswordCode",
                table: "Client");
        }
    }
}
