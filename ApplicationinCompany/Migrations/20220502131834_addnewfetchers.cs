using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addnewfetchers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "unitproject",
                type: "varchar(75)",
                maxLength: 75,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "finishesunit",
                type: "varchar(77)",
                maxLength: 77,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "ShowInWebSaite",
                table: "finishesunit",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "GideID",
                table: "customer",
                type: "varchar(90)",
                maxLength: 90,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 90)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "unitproject");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "finishesunit");

            migrationBuilder.DropColumn(
                name: "ShowInWebSaite",
                table: "finishesunit");

            migrationBuilder.UpdateData(
                table: "customer",
                keyColumn: "GideID",
                keyValue: null,
                column: "GideID",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "GideID",
                table: "customer",
                type: "varchar(90)",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 90,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
