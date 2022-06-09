using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addinviocenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberCommercial",
                table: "othercompanies",
                type: "varchar(35)",
                maxLength: 35,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "othercompanies",
                type: "varchar(77)",
                maxLength: 77,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "materials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "maker",
                type: "varchar(77)",
                maxLength: 77,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "finishcost",
                type: "varchar(70)",
                maxLength: 70,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "buildingcost",
                type: "varchar(70)",
                maxLength: 70,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_materials_IdCompany",
                table: "materials",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_materials_othercompanies_IdCompany",
                table: "materials",
                column: "IdCompany",
                principalTable: "othercompanies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_materials_othercompanies_IdCompany",
                table: "materials");

            migrationBuilder.DropIndex(
                name: "IX_materials_IdCompany",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "NumberCommercial",
                table: "othercompanies");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "othercompanies");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "maker");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "finishcost");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "buildingcost");
        }
    }
}
