using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace kolokwium_code_first_1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullfilledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_Orders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Orders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Product_Orders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Doe" },
                    { 2, "Jane", "Doe" },
                    { 3, "Julie", "Doe" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Apple", 3.45m },
                    { 2, "Banana", 2.5m },
                    { 3, "Orange", 1.5m }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Ongoing" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "ClientId", "CreatedAt", "FullfilledAt", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 2, 1, new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, 1, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 4, 2, new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Product_Orders",
                columns: new[] { "OrderId", "ProductId", "Amount" },
                values: new object[,]
                {
                    { 1, 1, 10 },
                    { 4, 1, 40 },
                    { 2, 2, 20 },
                    { 4, 2, 40 },
                    { 3, 3, 30 },
                    { 4, 3, 40 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusId",
                table: "Orders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Orders_OrderId",
                table: "Product_Orders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Orders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
