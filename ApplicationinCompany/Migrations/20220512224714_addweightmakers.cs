using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addweightmakers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "maker");

            migrationBuilder.AddColumn<int>(
                name: "Idweight",
                table: "maker",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_maker_Idweight",
                table: "maker",
                column: "Idweight");

            migrationBuilder.AddForeignKey(
                name: "FK_maker_weight_Idweight",
                table: "maker",
                column: "Idweight",
                principalTable: "weight",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_maker_weight_Idweight",
                table: "maker");

            migrationBuilder.DropIndex(
                name: "IX_maker_Idweight",
                table: "maker");

            migrationBuilder.DropColumn(
                name: "Idweight",
                table: "maker");

            migrationBuilder.AddColumn<double>(
                name: "Evaluation",
                table: "maker",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
