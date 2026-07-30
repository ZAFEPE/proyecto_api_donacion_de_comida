using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DONACIONES.Migrations
{
    /// <inheritdoc />
    public partial class DonorAndDonationsTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    donor_id = table.Column<string>(type: "TEXT", nullable: true),
                    DonationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    type_food = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    needs_refrigeration = table.Column<bool>(type: "INTEGER", nullable: false),
                    person_in_charge = table.Column<string>(type: "TEXT", nullable: true),
                    observations = table.Column<string>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    modified_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Donators",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    donor_type = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    dni = table.Column<string>(type: "TEXT", nullable: true),
                    contact_number = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    created_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_by_id = table.Column<string>(type: "TEXT", nullable: true),
                    modified_date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donators", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Donators");
        }
    }
}
