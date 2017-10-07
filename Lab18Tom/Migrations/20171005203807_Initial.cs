using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab18Tom.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationID);
                });

            migrationBuilder.CreateTable(
                name: "DestinationSupplies",
                columns: table => new
                {
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationsDestinationID = table.Column<int>(type: "int", nullable: true),
                    SuppyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationSupplies", x => x.DestinationID);
                    table.ForeignKey(
                        name: "FK_DestinationSupplies_Destinations_DestinationsDestinationID",
                        column: x => x.DestinationsDestinationID,
                        principalTable: "Destinations",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyID);
                    table.ForeignKey(
                        name: "FK_Supplies_DestinationSupplies_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "DestinationSupplies",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationSupplies_DestinationsDestinationID",
                table: "DestinationSupplies",
                column: "DestinationsDestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_DestinationID",
                table: "Supplies",
                column: "DestinationID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "DestinationSupplies");

            migrationBuilder.DropTable(
                name: "Destinations");
        }
    }
}
