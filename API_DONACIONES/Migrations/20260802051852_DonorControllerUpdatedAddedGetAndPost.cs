using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_DONACIONES.Migrations
{
    /// <inheritdoc />
    public partial class DonorControllerUpdatedAddedGetAndPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Donators",
                table: "Donators");

            migrationBuilder.RenameTable(
                name: "Donators",
                newName: "Donors");

            migrationBuilder.RenameColumn(
                name: "DonationDate",
                table: "Donations",
                newName: "donation_date");

            migrationBuilder.AddColumn<DateTime>(
                name: "expiration_date",
                table: "Donations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donors",
                table: "Donors",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_donor_id",
                table: "Donations",
                column: "donor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Donors_donor_id",
                table: "Donations",
                column: "donor_id",
                principalTable: "Donors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Donors_donor_id",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_donor_id",
                table: "Donations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donors",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "expiration_date",
                table: "Donations");

            migrationBuilder.RenameTable(
                name: "Donors",
                newName: "Donators");

            migrationBuilder.RenameColumn(
                name: "donation_date",
                table: "Donations",
                newName: "DonationDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donators",
                table: "Donators",
                column: "id");
        }
    }
}
