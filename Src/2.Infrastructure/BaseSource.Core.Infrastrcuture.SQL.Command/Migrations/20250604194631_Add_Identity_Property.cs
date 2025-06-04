using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseSource.Core.Infrastrcuture.SQL.Command.Migrations
{
    /// <inheritdoc />
    public partial class Add_Identity_Property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                schema: "Identity",
                table: "UserRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Identity",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Identity",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Identity",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Identity",
                table: "Roles");
        }
    }
}
