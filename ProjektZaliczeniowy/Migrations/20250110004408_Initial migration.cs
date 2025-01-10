using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektZaliczeniowy.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatalogNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalIssues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReceipts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalIssues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternalReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalReceipts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExternalIssueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalIssueId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalIssueDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalIssueDetails_ExternalIssues_ExternalIssueId",
                        column: x => x.ExternalIssueId,
                        principalTable: "ExternalIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalIssueDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalReceiptDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalReceiptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalReceiptDetails_ExternalReceipts_ExternalReceiptId",
                        column: x => x.ExternalReceiptId,
                        principalTable: "ExternalReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalReceiptDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalIssueDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalIssueId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalIssueDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalIssueDetails_InternalIssues_InternalIssueId",
                        column: x => x.InternalIssueId,
                        principalTable: "InternalIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalIssueDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalReceiptDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalReceiptId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalReceiptDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternalReceiptDetails_InternalReceipts_InternalReceiptId",
                        column: x => x.InternalReceiptId,
                        principalTable: "InternalReceipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternalReceiptDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsActive", "LastLogin", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, new DateTime(2025, 1, 10, 1, 44, 8, 106, DateTimeKind.Local).AddTicks(1904), true, null, "$2a$11$W3VMcQjRJP/cXEtTeU5NhuK0z9SWdzEhMCu7rXmSW3sm1bItl3tdC", "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalIssueDetails_ExternalIssueId",
                table: "ExternalIssueDetails",
                column: "ExternalIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalIssueDetails_ProductId",
                table: "ExternalIssueDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalIssues_UserId",
                table: "ExternalIssues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReceiptDetails_ExternalReceiptId",
                table: "ExternalReceiptDetails",
                column: "ExternalReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReceiptDetails_ProductId",
                table: "ExternalReceiptDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalReceipts_UserId",
                table: "ExternalReceipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalIssueDetails_InternalIssueId",
                table: "InternalIssueDetails",
                column: "InternalIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalIssueDetails_ProductId",
                table: "InternalIssueDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalIssues_UserId",
                table: "InternalIssues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalReceiptDetails_InternalReceiptId",
                table: "InternalReceiptDetails",
                column: "InternalReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalReceiptDetails_ProductId",
                table: "InternalReceiptDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalReceipts_UserId",
                table: "InternalReceipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalIssueDetails");

            migrationBuilder.DropTable(
                name: "ExternalReceiptDetails");

            migrationBuilder.DropTable(
                name: "InternalIssueDetails");

            migrationBuilder.DropTable(
                name: "InternalReceiptDetails");

            migrationBuilder.DropTable(
                name: "ExternalIssues");

            migrationBuilder.DropTable(
                name: "ExternalReceipts");

            migrationBuilder.DropTable(
                name: "InternalIssues");

            migrationBuilder.DropTable(
                name: "InternalReceipts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
