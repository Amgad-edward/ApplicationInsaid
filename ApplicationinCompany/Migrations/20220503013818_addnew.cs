using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class addnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Evaluation",
                table: "maker",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "IdEmplyee",
                table: "logadminis",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Persant",
                table: "emplyee",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GideID",
                table: "emplyee",
                type: "varchar(97)",
                maxLength: 97,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 90)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "TheJop",
                table: "emplyee",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<double>(
                name: "EvaluationCompany",
                table: "customer",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(type: "varchar(1200)", maxLength: 1200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCustomer = table.Column<int>(type: "int", nullable: false),
                    IdEmplyee = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    IsOkyDone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Think = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DoNotAgree = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HeIsCome = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Telephone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WhatsApp = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DoneReport = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_report_customer_idCustomer",
                        column: x => x.idCustomer,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_report_emplyee_IdEmplyee",
                        column: x => x.IdEmplyee,
                        principalTable: "emplyee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_logadminis_IdEmplyee",
                table: "logadminis",
                column: "IdEmplyee");

            migrationBuilder.CreateIndex(
                name: "IX_report_idCustomer",
                table: "report",
                column: "idCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_report_IdEmplyee",
                table: "report",
                column: "IdEmplyee");

            migrationBuilder.AddForeignKey(
                name: "FK_logadminis_emplyee_IdEmplyee",
                table: "logadminis",
                column: "IdEmplyee",
                principalTable: "emplyee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_logadminis_emplyee_IdEmplyee",
                table: "logadminis");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropIndex(
                name: "IX_logadminis_IdEmplyee",
                table: "logadminis");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "maker");

            migrationBuilder.DropColumn(
                name: "IdEmplyee",
                table: "logadminis");

            migrationBuilder.DropColumn(
                name: "TheJop",
                table: "emplyee");

            migrationBuilder.DropColumn(
                name: "EvaluationCompany",
                table: "customer");

            migrationBuilder.AlterColumn<int>(
                name: "Persant",
                table: "emplyee",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.UpdateData(
                table: "emplyee",
                keyColumn: "GideID",
                keyValue: null,
                column: "GideID",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "GideID",
                table: "emplyee",
                type: "varchar(90)",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(97)",
                oldMaxLength: 97,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
