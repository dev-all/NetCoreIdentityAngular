using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoProveedor_Proveedor_ProveedorId",
                table: "ProductoProveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor");

            migrationBuilder.RenameTable(
                name: "Proveedor",
                newName: "Proveedores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoProveedor_Proveedores_ProveedorId",
                table: "ProductoProveedor",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoProveedor_Proveedores_ProveedorId",
                table: "ProductoProveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proveedores",
                table: "Proveedores");

            migrationBuilder.RenameTable(
                name: "Proveedores",
                newName: "Proveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proveedor",
                table: "Proveedor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoProveedor_Proveedor_ProveedorId",
                table: "ProductoProveedor",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id");
        }
    }
}
