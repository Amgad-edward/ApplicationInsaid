using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addcomid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCompany",
                table: "taskcarry",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_taskcarry_IdCompany",
                table: "taskcarry",
                column: "IdCompany");

            migrationBuilder.AddForeignKey(
                name: "FK_taskcarry_othercompanies_IdCompany",
                table: "taskcarry",
                column: "IdCompany",
                principalTable: "othercompanies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taskcarry_othercompanies_IdCompany",
                table: "taskcarry");

            migrationBuilder.DropIndex(
                name: "IX_taskcarry_IdCompany",
                table: "taskcarry");

            migrationBuilder.DropColumn(
                name: "IdCompany",
                table: "taskcarry");
        }
    }
}
