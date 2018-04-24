using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoffeePoint.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Percetage = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountGuid);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductGuid = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductGuid);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserGuid);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountGuid = table.Column<Guid>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountGuid);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CashierShifts",
                columns: table => new
                {
                    ShiftGuid = table.Column<Guid>(nullable: false),
                    ClosedByUserGuid = table.Column<Guid>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    OpenedByUserGuid = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashierShifts", x => x.ShiftGuid);
                    table.ForeignKey(
                        name: "FK_CashierShifts_Users_ClosedByUserGuid",
                        column: x => x.ClosedByUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashierShifts_Users_OpenedByUserGuid",
                        column: x => x.OpenedByUserGuid,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderGuid = table.Column<Guid>(nullable: false),
                    ClosedDate = table.Column<DateTimeOffset>(nullable: true),
                    DiscountGuid = table.Column<Guid>(nullable: true),
                    OpenDate = table.Column<DateTimeOffset>(nullable: false),
                    ShiftGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderGuid);
                    table.ForeignKey(
                        name: "FK_Orders_Discounts_DiscountGuid",
                        column: x => x.DiscountGuid,
                        principalTable: "Discounts",
                        principalColumn: "DiscountGuid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_CashierShifts_ShiftGuid",
                        column: x => x.ShiftGuid,
                        principalTable: "CashierShifts",
                        principalColumn: "ShiftGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ItemGuid = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    OrderGuid = table.Column<Guid>(nullable: false),
                    ProductGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ItemGuid);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderGuid",
                        column: x => x.OrderGuid,
                        principalTable: "Orders",
                        principalColumn: "OrderGuid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductGuid",
                        column: x => x.ProductGuid,
                        principalTable: "Products",
                        principalColumn: "ProductGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TypeId",
                table: "Accounts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CashierShifts_ClosedByUserGuid",
                table: "CashierShifts",
                column: "ClosedByUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CashierShifts_OpenedByUserGuid",
                table: "CashierShifts",
                column: "OpenedByUserGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderGuid",
                table: "OrderItems",
                column: "OrderGuid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductGuid",
                table: "OrderItems",
                column: "ProductGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountGuid",
                table: "Orders",
                column: "DiscountGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShiftGuid",
                table: "Orders",
                column: "ShiftGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "CashierShifts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
