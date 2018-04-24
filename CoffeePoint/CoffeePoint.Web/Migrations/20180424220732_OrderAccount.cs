using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoffeePoint.Web.Migrations
{
    public partial class OrderAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Orders",
                newName: "Total");

            migrationBuilder.AddColumn<Guid>(
                name: "AccountGuid",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AccountGuid",
                table: "Orders",
                column: "AccountGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountGuid",
                table: "Orders",
                column: "AccountGuid",
                principalTable: "Accounts",
                principalColumn: "AccountGuid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountGuid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AccountGuid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AccountGuid",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "Balance");
        }
    }
}
