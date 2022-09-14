using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyMicroservice.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessMaster",
                columns: table => new
                {
                    BusinessMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessValue = table.Column<int>(type: "int", nullable: false),
                    BusinessTurnOver = table.Column<int>(type: "int", nullable: false),
                    CapitalInvest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessMaster", x => x.BusinessMasterId);
                });

            migrationBuilder.CreateTable(
                name: "createpolicies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    AcceptedQuotes = table.Column<int>(type: "int", nullable: false),
                    PolicyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_createpolicies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyMaster",
                columns: table => new
                {
                    PolicyMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    ConsumerType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    AssuredSum = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false),
                    BusinesssValue = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false),
                    BaseLocation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PolicyType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PolicyMa__2B2E4F00B7651340", x => x.PolicyMasterId);
                });

            migrationBuilder.CreateTable(
                name: "PropertyMaster",
                columns: table => new
                {
                    PropertyMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostOfAssest = table.Column<int>(type: "int", nullable: false),
                    SalvageValue = table.Column<int>(type: "int", nullable: false),
                    UsefulLifeOfAssest = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyMaster", x => x.PropertyMasterId);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    QuoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyValueFrom = table.Column<int>(type: "int", nullable: false),
                    PropertyValueTo = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueFrom = table.Column<int>(type: "int", nullable: false),
                    BusinesssValueTo = table.Column<int>(type: "int", nullable: false),
                    PropertyType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    QuoteValue = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.QuoteId);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    PanNumber = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.ConsumerId);
                    table.ForeignKey(
                        name: "FK__Consumer__AgentI__267ABA7A",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BusinessType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TotalEmployees = table.Column<int>(type: "int", nullable: false),
                    BusinessMasterId = table.Column<int>(type: "int", nullable: false),
                    ConsumerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK__Business__Busine__2D27B809",
                        column: x => x.BusinessMasterId,
                        principalTable: "BusinessMaster",
                        principalColumn: "BusinessMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Business__Consum__2E1BDC42",
                        column: x => x.ConsumerID,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BuildingStoreys = table.Column<int>(type: "int", nullable: false),
                    BuildingAge = table.Column<int>(type: "int", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    PropertyMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK__Property__Busine__30F848ED",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "BusinessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Property__Proper__31EC6D26",
                        column: x => x.PropertyMasterId,
                        principalTable: "PropertyMaster",
                        principalColumn: "PropertyMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumerPolicy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    QuoteId = table.Column<int>(type: "int", nullable: false),
                    PolicyStatus = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PolicyMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consumer__2E1339A4567C4E44", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK__ConsumerP__Polic__3A81B327",
                        column: x => x.PolicyMasterId,
                        principalTable: "PolicyMaster",
                        principalColumn: "PolicyMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ConsumerP__Prope__38996AB5",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ConsumerP__Quote__398D8EEE",
                        column: x => x.QuoteId,
                        principalTable: "Quote",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessMasterId",
                table: "Business",
                column: "BusinessMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_ConsumerID",
                table: "Business",
                column: "ConsumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Consumer_AgentId",
                table: "Consumer",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicy_PolicyMasterId",
                table: "ConsumerPolicy",
                column: "PolicyMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicy_PropertyId",
                table: "ConsumerPolicy",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumerPolicy_QuoteId",
                table: "ConsumerPolicy",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_BusinessId",
                table: "Property",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyMasterId",
                table: "Property",
                column: "PropertyMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumerPolicy");

            migrationBuilder.DropTable(
                name: "createpolicies");

            migrationBuilder.DropTable(
                name: "PolicyMaster");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Quote");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "PropertyMaster");

            migrationBuilder.DropTable(
                name: "BusinessMaster");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Agent");
        }
    }
}
