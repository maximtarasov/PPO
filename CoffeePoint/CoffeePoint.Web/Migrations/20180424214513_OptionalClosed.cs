using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoffeePoint.Web.Migrations
{
    public partial class OptionalClosed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashierShifts_Users_ClosedByUserGuid",
                table: "CashierShifts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClosedByUserGuid",
                table: "CashierShifts",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_CashierShifts_Users_ClosedByUserGuid",
                table: "CashierShifts",
                column: "ClosedByUserGuid",
                principalTable: "Users",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashierShifts_Users_ClosedByUserGuid",
                table: "CashierShifts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClosedByUserGuid",
                table: "CashierShifts",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CashierShifts_Users_ClosedByUserGuid",
                table: "CashierShifts",
                column: "ClosedByUserGuid",
                principalTable: "Users",
                principalColumn: "UserGuid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
