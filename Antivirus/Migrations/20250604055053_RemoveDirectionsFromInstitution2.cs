using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDirectionsFromInstitution2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Institutions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "Institutions",
                type: "bigint",
                nullable: true);
        }
    }
}
