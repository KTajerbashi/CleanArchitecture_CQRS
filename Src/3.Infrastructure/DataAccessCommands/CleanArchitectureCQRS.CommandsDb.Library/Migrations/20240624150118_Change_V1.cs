using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitectureCQRS.CommandsDb.Library.Migrations
{
    /// <inheritdoc />
    public partial class Change_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Test",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Test",
                table: "People");
        }
    }
}
