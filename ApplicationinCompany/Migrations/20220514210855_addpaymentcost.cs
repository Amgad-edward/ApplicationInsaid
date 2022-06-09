using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addpaymentcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "thepaymentcost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdBuildingcost = table.Column<int>(type: "int", nullable: true),
                    IdBFinishingcost = table.Column<int>(type: "int", nullable: true),
                    ManeyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thepaymentcost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thepaymentcost_buildingcost_IdBuildingcost",
                        column: x => x.IdBuildingcost,
                        principalTable: "buildingcost",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_thepaymentcost_finishcost_IdBFinishingcost",
                        column: x => x.IdBFinishingcost,
                        principalTable: "finishcost",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_thepaymentcost_IdBFinishingcost",
                table: "thepaymentcost",
                column: "IdBFinishingcost");

            migrationBuilder.CreateIndex(
                name: "IX_thepaymentcost_IdBuildingcost",
                table: "thepaymentcost",
                column: "IdBuildingcost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thepaymentcost");
        }
    }
}
