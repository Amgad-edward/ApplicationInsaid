using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addtablesnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "emplyee",
                newName: "DateBirth");

            migrationBuilder.AddColumn<int>(
                name: "IdCompanysGet",
                table: "finishesunit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEpmlyee",
                table: "finishesunit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "date",
                table: "finishesunit",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirth",
                table: "emplyee",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.CreateTable(
                name: "othercompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialty = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    NameManegar = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iscompetitivecompany = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsCompanyToBenefit = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Persant = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_othercompanies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "taskcarry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TheTask = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmplyee = table.Column<int>(type: "int", nullable: false),
                    DoneTask = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Resulte = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskcarry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskcarry_emplyee_IdEmplyee",
                        column: x => x.IdEmplyee,
                        principalTable: "emplyee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "accountothercompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idcompany = table.Column<int>(type: "int", nullable: false),
                    OtherCompaniesId = table.Column<int>(type: "int", nullable: true),
                    Maney = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountothercompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_accountothercompany_othercompanies_OtherCompaniesId",
                        column: x => x.OtherCompaniesId,
                        principalTable: "othercompanies",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_finishesunit_IdCompanysGet",
                table: "finishesunit",
                column: "IdCompanysGet");

            migrationBuilder.CreateIndex(
                name: "IX_finishesunit_IdEpmlyee",
                table: "finishesunit",
                column: "IdEpmlyee");

            migrationBuilder.CreateIndex(
                name: "IX_accountothercompany_OtherCompaniesId",
                table: "accountothercompany",
                column: "OtherCompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_taskcarry_IdEmplyee",
                table: "taskcarry",
                column: "IdEmplyee");

            migrationBuilder.AddForeignKey(
                name: "FK_finishesunit_emplyee_IdEpmlyee",
                table: "finishesunit",
                column: "IdEpmlyee",
                principalTable: "emplyee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_finishesunit_othercompanies_IdCompanysGet",
                table: "finishesunit",
                column: "IdCompanysGet",
                principalTable: "othercompanies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_finishesunit_emplyee_IdEpmlyee",
                table: "finishesunit");

            migrationBuilder.DropForeignKey(
                name: "FK_finishesunit_othercompanies_IdCompanysGet",
                table: "finishesunit");

            migrationBuilder.DropTable(
                name: "accountothercompany");

            migrationBuilder.DropTable(
                name: "taskcarry");

            migrationBuilder.DropTable(
                name: "othercompanies");

            migrationBuilder.DropIndex(
                name: "IX_finishesunit_IdCompanysGet",
                table: "finishesunit");

            migrationBuilder.DropIndex(
                name: "IX_finishesunit_IdEpmlyee",
                table: "finishesunit");

            migrationBuilder.DropColumn(
                name: "IdCompanysGet",
                table: "finishesunit");

            migrationBuilder.DropColumn(
                name: "IdEpmlyee",
                table: "finishesunit");

            migrationBuilder.DropColumn(
                name: "date",
                table: "finishesunit");

            migrationBuilder.RenameColumn(
                name: "DateBirth",
                table: "emplyee",
                newName: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "emplyee",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
