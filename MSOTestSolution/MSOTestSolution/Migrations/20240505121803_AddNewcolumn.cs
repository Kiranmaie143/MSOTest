using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MSOTestSolution.Migrations
{
    /// <inheritdoc />
    public partial class AddNewcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cockpits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cockpits");
        }
    }
}
