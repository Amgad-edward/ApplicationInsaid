using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class uniyadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ISPaymentDone",
                table: "finishcost",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IDEgy",
                table: "customer",
                type: "varchar(17)",
                maxLength: 17,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "ISPaymentDone",
                table: "buildingcost",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISPaymentDone",
                table: "finishcost");

            migrationBuilder.DropColumn(
                name: "IDEgy",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "ISPaymentDone",
                table: "buildingcost");
        }
    }
}
