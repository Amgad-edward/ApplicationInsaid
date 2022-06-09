using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addtabbles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFinishUint",
                table: "resertvationandsale",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Idmaker",
                table: "buildingcost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "finishesunit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idcategory = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    SapceMetar = table.Column<double>(type: "double", nullable: false),
                    TotalPriceBuy = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Information = table.Column<string>(type: "varchar(170)", maxLength: 170, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUintResertvation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishesunit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_finishesunit_category_Idcategory",
                        column: x => x.Idcategory,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_finishesunit_customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "maker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameMaker = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GideID = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JopTitel = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phones = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maker", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "imagedesignfinish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdunitFinish = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "longblob", maxLength: 100000000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagedesignfinish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagedesignfinish_finishesunit_IdunitFinish",
                        column: x => x.IdunitFinish,
                        principalTable: "finishesunit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "finishcost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUnitFinish = table.Column<int>(type: "int", nullable: false),
                    Idmaker = table.Column<int>(type: "int", nullable: true),
                    IdMaterail = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finishcost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_finishcost_finishesunit_IdUnitFinish",
                        column: x => x.IdUnitFinish,
                        principalTable: "finishesunit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_finishcost_maker_Idmaker",
                        column: x => x.Idmaker,
                        principalTable: "maker",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_finishcost_materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "materials",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_resertvationandsale_IdFinishUint",
                table: "resertvationandsale",
                column: "IdFinishUint",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_buildingcost_Idmaker",
                table: "buildingcost",
                column: "Idmaker");

            migrationBuilder.CreateIndex(
                name: "IX_finishcost_Idmaker",
                table: "finishcost",
                column: "Idmaker");

            migrationBuilder.CreateIndex(
                name: "IX_finishcost_IdUnitFinish",
                table: "finishcost",
                column: "IdUnitFinish");

            migrationBuilder.CreateIndex(
                name: "IX_finishcost_MaterialId",
                table: "finishcost",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_finishesunit_Idcategory",
                table: "finishesunit",
                column: "Idcategory");

            migrationBuilder.CreateIndex(
                name: "IX_finishesunit_IdCustomer",
                table: "finishesunit",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_imagedesignfinish_IdunitFinish",
                table: "imagedesignfinish",
                column: "IdunitFinish");

            migrationBuilder.AddForeignKey(
                name: "FK_buildingcost_maker_Idmaker",
                table: "buildingcost",
                column: "Idmaker",
                principalTable: "maker",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_resertvationandsale_finishesunit_IdFinishUint",
                table: "resertvationandsale",
                column: "IdFinishUint",
                principalTable: "finishesunit",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buildingcost_maker_Idmaker",
                table: "buildingcost");

            migrationBuilder.DropForeignKey(
                name: "FK_resertvationandsale_finishesunit_IdFinishUint",
                table: "resertvationandsale");

            migrationBuilder.DropTable(
                name: "finishcost");

            migrationBuilder.DropTable(
                name: "imagedesignfinish");

            migrationBuilder.DropTable(
                name: "maker");

            migrationBuilder.DropTable(
                name: "finishesunit");

            migrationBuilder.DropIndex(
                name: "IX_resertvationandsale_IdFinishUint",
                table: "resertvationandsale");

            migrationBuilder.DropIndex(
                name: "IX_buildingcost_Idmaker",
                table: "buildingcost");

            migrationBuilder.DropColumn(
                name: "IdFinishUint",
                table: "resertvationandsale");

            migrationBuilder.DropColumn(
                name: "Idmaker",
                table: "buildingcost");
        }
    }
}
