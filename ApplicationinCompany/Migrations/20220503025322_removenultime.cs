using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class removenultime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTimeWork",
                table: "emplyee",
                type: "time(0)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTimeWork",
                table: "emplyee",
                type: "time(0)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTimeWork",
                table: "emplyee",
                type: "time(0)",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "EndTimeWork",
                table: "emplyee",
                type: "time(0)",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time(0)");
        }
    }
}
