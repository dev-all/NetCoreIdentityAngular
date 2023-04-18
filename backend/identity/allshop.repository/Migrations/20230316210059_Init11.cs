using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "IdUsuario",
                table: "Cliente",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "IdImputacion",
                table: "Cliente",
                newName: "DireccionId");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPais = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProvincia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdLocalidad = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoAfip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oobservacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DireccionId",
                table: "Cliente",
                column: "DireccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Direccion_DireccionId",
                table: "Cliente",
                column: "DireccionId",
                principalTable: "Direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Direccion_DireccionId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_DireccionId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Cliente",
                newName: "IdUsuario");

            migrationBuilder.RenameColumn(
                name: "DireccionId",
                table: "Cliente",
                newName: "IdImputacion");

            migrationBuilder.AddColumn<Guid>(
                name: "IdDireccion",
                table: "Cliente",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
