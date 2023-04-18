using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Cliente_ClienteId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_ClienteId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "Cliente");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Direcciones",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ClienteId",
                table: "Direcciones",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Cliente_ClienteId",
                table: "Direcciones",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Cliente_ClienteId",
                table: "Direcciones");

            migrationBuilder.DropIndex(
                name: "IX_Direcciones_ClienteId",
                table: "Direcciones");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Direcciones");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Cliente",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DireccionId",
                table: "Cliente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ClienteId",
                table: "Cliente",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Cliente_ClienteId",
                table: "Cliente",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }
    }
}
