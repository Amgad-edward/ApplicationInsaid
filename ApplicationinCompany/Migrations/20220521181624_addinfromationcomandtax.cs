using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addinfromationcomandtax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DoneRequistTax",
                table: "finishesunit",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ApiToken",
                table: "company",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IDCompanyApi",
                table: "company",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Maneger",
                table: "company",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumberCommercialRecord",
                table: "company",
                type: "varchar(70)",
                maxLength: 70,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumberTax",
                table: "company",
                type: "varchar(70)",
                maxLength: 70,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Security1",
                table: "company",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Security2",
                table: "company",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TitleActivity",
                table: "company",
                type: "varchar(70)",
                maxLength: 70,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "DoneRequistTax",
                table: "buildingcost",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneRequistTax",
                table: "finishesunit");

            migrationBuilder.DropColumn(
                name: "ApiToken",
                table: "company");

            migrationBuilder.DropColumn(
                name: "IDCompanyApi",
                table: "company");

            migrationBuilder.DropColumn(
                name: "Maneger",
                table: "company");

            migrationBuilder.DropColumn(
                name: "NumberCommercialRecord",
                table: "company");

            migrationBuilder.DropColumn(
                name: "NumberTax",
                table: "company");

            migrationBuilder.DropColumn(
                name: "Security1",
                table: "company");

            migrationBuilder.DropColumn(
                name: "Security2",
                table: "company");

            migrationBuilder.DropColumn(
                name: "TitleActivity",
                table: "company");

            migrationBuilder.DropColumn(
                name: "DoneRequistTax",
                table: "buildingcost");
        }
    }
}
