using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationinCompany.Migrations
{
    public partial class CreateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCompany = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phones = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Locations = table.Column<string>(type: "varchar(115)", maxLength: 115, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Information = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logo = table.Column<byte[]>(type: "longblob", maxLength: 10000000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameCustomer = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phones = table.Column<string>(type: "varchar(75)", maxLength: 75, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneSms = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GideID = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "emplyee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TitleJop = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BaseSalery = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Persant = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartWork = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTimeWork = table.Column<TimeOnly>(type: "time(0)", nullable: true),
                    EndTimeWork = table.Column<TimeOnly>(type: "time(0)", nullable: true),
                    WeekEnd = table.Column<int>(type: "int", nullable: false),
                    GideID = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emplyee", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "floor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameFloor = table.Column<string>(type: "varchar(47)", maxLength: 47, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectInfo = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountFloor = table.Column<int>(type: "int", nullable: false),
                    TotalSapce = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameWeight = table.Column<string>(type: "varchar(31)", maxLength: 31, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdWeightsmall = table.Column<int>(type: "int", nullable: true),
                    CountOfSmall = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_weight_weight_IdWeightsmall",
                        column: x => x.IdWeightsmall,
                        principalTable: "weight",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "attendingandleaving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idemplyee = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Attending = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Leaving = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendingandleaving", x => x.Id);
                    table.ForeignKey(
                        name: "FK_attendingandleaving_emplyee_Idemplyee",
                        column: x => x.Idemplyee,
                        principalTable: "emplyee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salerypayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idemplyee = table.Column<int>(type: "int", nullable: false),
                    ToMonth = table.Column<int>(type: "int", nullable: false),
                    MoneyTake = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    SaleOF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salerypayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_salerypayment_emplyee_Idemplyee",
                        column: x => x.Idemplyee,
                        principalTable: "emplyee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "projectimage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idproject = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "longblob", maxLength: 10000000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projectimage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projectimage_project_Idproject",
                        column: x => x.Idproject,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameMaterial = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idweight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_materials_weight_Idweight",
                        column: x => x.Idweight,
                        principalTable: "weight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "buildingcost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ToAccount = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CountWeight = table.Column<double>(type: "double", nullable: false),
                    IdMaterial = table.Column<int>(type: "int", nullable: true),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildingcost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buildingcost_materials_IdMaterial",
                        column: x => x.IdMaterial,
                        principalTable: "materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_buildingcost_project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "paymantmoney",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Idsale = table.Column<int>(type: "int", nullable: false),
                    Money = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Paymentis = table.Column<int>(type: "int", nullable: false),
                    CashPayment = table.Column<int>(type: "int", nullable: false),
                    NumberPaymentProcess = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SheekBank = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DatePayment = table.Column<DateTime>(type: " date", nullable: false),
                    DonePayment = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymantmoney", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resertvationandsale",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUnit = table.Column<int>(type: "int", nullable: false),
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    TotalPriceBuy = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PriceAdding = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    systemPayments = table.Column<int>(type: "int", nullable: false),
                    DateSale = table.Column<DateOnly>(type: "date", nullable: false),
                    IdEmplyee = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resertvationandsale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_resertvationandsale_customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resertvationandsale_emplyee_IdEmplyee",
                        column: x => x.IdEmplyee,
                        principalTable: "emplyee",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unitproject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpaceMater = table.Column<double>(type: "double", nullable: false),
                    IdProject = table.Column<int>(type: "int", nullable: false),
                    Idcategory = table.Column<int>(type: "int", nullable: false),
                    IdFloor = table.Column<int>(type: "int", nullable: false),
                    UnitNumber = table.Column<int>(type: "int", nullable: false),
                    MapImage = table.Column<byte[]>(type: "longblob", maxLength: 10000000, nullable: true),
                    Description = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdResetvationsale = table.Column<int>(type: "int", nullable: true),
                    AdvertisementForTheCustomer = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitproject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unitproject_category_Idcategory",
                        column: x => x.Idcategory,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unitproject_floor_IdFloor",
                        column: x => x.IdFloor,
                        principalTable: "floor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unitproject_project_IdProject",
                        column: x => x.IdProject,
                        principalTable: "project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unitproject_resertvationandsale_IdResetvationsale",
                        column: x => x.IdResetvationsale,
                        principalTable: "resertvationandsale",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_attendingandleaving_Idemplyee",
                table: "attendingandleaving",
                column: "Idemplyee");

            migrationBuilder.CreateIndex(
                name: "IX_buildingcost_IdMaterial",
                table: "buildingcost",
                column: "IdMaterial");

            migrationBuilder.CreateIndex(
                name: "IX_buildingcost_IdProject",
                table: "buildingcost",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_materials_Idweight",
                table: "materials",
                column: "Idweight");

            migrationBuilder.CreateIndex(
                name: "IX_paymantmoney_Idsale",
                table: "paymantmoney",
                column: "Idsale");

            migrationBuilder.CreateIndex(
                name: "IX_projectimage_Idproject",
                table: "projectimage",
                column: "Idproject");

            migrationBuilder.CreateIndex(
                name: "IX_resertvationandsale_IdCustomer",
                table: "resertvationandsale",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_resertvationandsale_IdEmplyee",
                table: "resertvationandsale",
                column: "IdEmplyee");

            migrationBuilder.CreateIndex(
                name: "IX_resertvationandsale_IdUnit",
                table: "resertvationandsale",
                column: "IdUnit");

            migrationBuilder.CreateIndex(
                name: "IX_salerypayment_Idemplyee",
                table: "salerypayment",
                column: "Idemplyee");

            migrationBuilder.CreateIndex(
                name: "IX_unitproject_Idcategory",
                table: "unitproject",
                column: "Idcategory");

            migrationBuilder.CreateIndex(
                name: "IX_unitproject_IdFloor",
                table: "unitproject",
                column: "IdFloor");

            migrationBuilder.CreateIndex(
                name: "IX_unitproject_IdProject",
                table: "unitproject",
                column: "IdProject");

            migrationBuilder.CreateIndex(
                name: "IX_unitproject_IdResetvationsale",
                table: "unitproject",
                column: "IdResetvationsale");

            migrationBuilder.CreateIndex(
                name: "IX_weight_IdWeightsmall",
                table: "weight",
                column: "IdWeightsmall");

            migrationBuilder.AddForeignKey(
                name: "FK_paymantmoney_resertvationandsale_Idsale",
                table: "paymantmoney",
                column: "Idsale",
                principalTable: "resertvationandsale",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_resertvationandsale_unitproject_IdUnit",
                table: "resertvationandsale",
                column: "IdUnit",
                principalTable: "unitproject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resertvationandsale_emplyee_IdEmplyee",
                table: "resertvationandsale");

            migrationBuilder.DropForeignKey(
                name: "FK_unitproject_project_IdProject",
                table: "unitproject");

            migrationBuilder.DropForeignKey(
                name: "FK_unitproject_resertvationandsale_IdResetvationsale",
                table: "unitproject");

            migrationBuilder.DropTable(
                name: "attendingandleaving");

            migrationBuilder.DropTable(
                name: "buildingcost");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "paymantmoney");

            migrationBuilder.DropTable(
                name: "projectimage");

            migrationBuilder.DropTable(
                name: "salerypayment");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "weight");

            migrationBuilder.DropTable(
                name: "emplyee");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "resertvationandsale");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "unitproject");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "floor");
        }
    }
}
