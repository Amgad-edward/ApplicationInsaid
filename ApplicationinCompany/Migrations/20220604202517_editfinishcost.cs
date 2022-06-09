using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class editfinishcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishcost_materials_MaterialId",
                table: "finishcost");

            migrationBuilder.DropIndex(
                name: "IX_finishcost_MaterialId",
                table: "finishcost");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "finishcost");

            migrationBuilder.CreateIndex(
                name: "IX_finishcost_IdMaterail",
                table: "finishcost",
                column: "IdMaterail");

            migrationBuilder.AddForeignKey(
                name: "FK_finishcost_materials_IdMaterail",
                table: "finishcost",
                column: "IdMaterail",
                principalTable: "materials",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishcost_materials_IdMaterail",
                table: "finishcost");

            migrationBuilder.DropIndex(
                name: "IX_finishcost_IdMaterail",
                table: "finishcost");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "finishcost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_finishcost_MaterialId",
                table: "finishcost",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_finishcost_materials_MaterialId",
                table: "finishcost",
                column: "MaterialId",
                principalTable: "materials",
                principalColumn: "Id");
        }
    }
}
