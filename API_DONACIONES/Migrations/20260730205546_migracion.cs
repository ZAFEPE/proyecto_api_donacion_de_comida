using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DONACIONES.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "observations",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "person_in_charge",
                table: "Donations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "observations",
                table: "Donations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "person_in_charge",
                table: "Donations",
                type: "TEXT",
                nullable: true);
        }
    }
}
