using Microsoft.EntityFrameworkCore.Migrations;

namespace ZillowAPI.Data.Migrations
{
    public partial class Edit_adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_RealEstates_RealEstateId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_RealEstateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "RealEstates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_AddressId",
                table: "RealEstates",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstates_Addresses_AddressId",
                table: "RealEstates",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstates_Addresses_AddressId",
                table: "RealEstates");

            migrationBuilder.DropIndex(
                name: "IX_RealEstates_AddressId",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "RealEstates");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_RealEstateId",
                table: "Addresses",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_RealEstates_RealEstateId",
                table: "Addresses",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
