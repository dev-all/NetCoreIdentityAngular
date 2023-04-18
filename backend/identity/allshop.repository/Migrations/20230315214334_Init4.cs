using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoMasOpciones_Producto_ProductoId",
                table: "ProductoMasOpciones");

            migrationBuilder.DropIndex(
                name: "IX_ProductoMasOpciones_ProductoId",
                table: "ProductoMasOpciones");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ProductoMasOpciones");

            migrationBuilder.AddColumn<Guid>(
                name: "ImputacionId",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoEstadoId",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoMasOpcionesId",
                table: "Producto",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Imputaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSubRubro = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaldoFin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipo = table.Column<int>(type: "int", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enero = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Febrero = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Marzo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Abril = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Mayo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Junio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Julio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Agosto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Septiembre = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Octubre = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Noviembre = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Diciembre = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    UltimaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imputaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoEstado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoEstado", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ImputacionId",
                table: "Producto",
                column: "ImputacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoEstadoId",
                table: "Producto",
                column: "ProductoEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_ProductoMasOpcionesId",
                table: "Producto",
                column: "ProductoMasOpcionesId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Imputaciones_ImputacionId",
                table: "Producto",
                column: "ImputacionId",
                principalTable: "Imputaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ProductoEstado_ProductoEstadoId",
                table: "Producto",
                column: "ProductoEstadoId",
                principalTable: "ProductoEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_ProductoMasOpciones_ProductoMasOpcionesId",
                table: "Producto",
                column: "ProductoMasOpcionesId",
                principalTable: "ProductoMasOpciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Imputaciones_ImputacionId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ProductoEstado_ProductoEstadoId",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_ProductoMasOpciones_ProductoMasOpcionesId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "Imputaciones");

            migrationBuilder.DropTable(
                name: "ProductoEstado");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ImputacionId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProductoEstadoId",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_ProductoMasOpcionesId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ImputacionId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ProductoEstadoId",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "ProductoMasOpcionesId",
                table: "Producto");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoId",
                table: "ProductoMasOpciones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMasOpciones_ProductoId",
                table: "ProductoMasOpciones",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoMasOpciones_Producto_ProductoId",
                table: "ProductoMasOpciones",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
