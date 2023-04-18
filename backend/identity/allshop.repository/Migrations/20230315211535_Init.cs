using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "EmailAlternativo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NombreElegido = table.Column<string>(type: "varchar(100)", nullable: false),
                    ApellidoElegido = table.Column<string>(type: "varchar(100)", nullable: false),
                    NombreEnDocumento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Documento = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdImputacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(max)", nullable: true),
                    IdPieNota = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdTipoIva = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NIF = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdEntidad = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdDireccion = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(50)", nullable: true),
                    Movil = table.Column<string>(type: "varchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Web = table.Column<string>(type: "varchar(50)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Referencia = table.Column<string>(type: "varchar(250)", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(350)", nullable: true),
                    DescripcionCorta = table.Column<string>(type: "varchar(150)", nullable: false),
                    Observaciones = table.Column<string>(type: "varchar(max)", nullable: true),
                    Codigo = table.Column<string>(type: "varchar(20)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "varchar(250)", nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PrecioAlmacen = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PrecioTienda = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PrecioWeb = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PrecioPvp = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    PrecioIva = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoProveedor",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedor", x => new { x.IdProducto, x.IdProveedor });
                });

            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoClave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extencion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TamanoKb = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivo_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoMasOpciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMarca = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicacionWeb = table.Column<bool>(type: "bit", nullable: false),
                    Kilo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Litro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadPorCaja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ancho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Largo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoMasOpciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoMasOpciones_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_ProductoId",
                table: "Archivo",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMasOpciones_ProductoId",
                table: "ProductoMasOpciones",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ProductoMasOpciones");

            migrationBuilder.DropTable(
                name: "ProductoProveedor");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropColumn(
                name: "EmailAlternativo",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "varchar(250)", nullable: false),
                    NIF = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }
    }
}
