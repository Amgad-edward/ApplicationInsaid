using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addcodeing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ICode",
                table: "materials",
                newName: "ICodeGS1");

            migrationBuilder.AddColumn<string>(
                name: "CategoryNameEnglish",
                table: "category",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryNameEnglish",
                table: "category");

            migrationBuilder.RenameColumn(
                name: "ICodeGS1",
                table: "materials",
                newName: "ICode");
        }
    }
}
