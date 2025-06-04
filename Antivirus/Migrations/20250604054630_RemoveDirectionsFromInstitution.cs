using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDirectionsFromInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Directions",
                table: "Institutions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Directions",
                table: "Institutions",
                type: "text",
                nullable: true);
        }
    }
}
