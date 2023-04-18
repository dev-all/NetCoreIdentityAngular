using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImputacionId",
                table: "Cliente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ImputacionId",
                table: "Cliente",
                column: "ImputacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Imputaciones_ImputacionId",
                table: "Cliente",
                column: "ImputacionId",
                principalTable: "Imputaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Imputaciones_ImputacionId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_ImputacionId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ImputacionId",
                table: "Cliente");
        }
    }
}
