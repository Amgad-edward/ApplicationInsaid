using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addsdateonfinsgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "finishcost",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "finishcost");
        }
    }
}
