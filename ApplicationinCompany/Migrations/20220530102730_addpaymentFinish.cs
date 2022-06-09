using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addpaymentFinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "paymantmoney",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: " date");

            migrationBuilder.CreateTable(
                name: "paymentfinish",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFinish = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Paymentis = table.Column<int>(type: "int", nullable: false),
                    CashPayment = table.Column<int>(type: "int", nullable: false),
                    NumberPaymentProcess = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SheekBank = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatePayment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DonePayment = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentfinish", x => x.ID);
                    table.ForeignKey(
                        name: "FK_paymentfinish_finishesunit_IdFinish",
                        column: x => x.IdFinish,
                        principalTable: "finishesunit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_paymentfinish_IdFinish",
                table: "paymentfinish",
                column: "IdFinish");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "paymentfinish");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePayment",
                table: "paymantmoney",
                type: " date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
