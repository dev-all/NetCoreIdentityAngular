using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace allshop.repository.Migrations
{
    public partial class Init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaId",
                table: "Localidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincia_Pais_PaisId",
                table: "Provincia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provincia",
                table: "Provincia");

            migrationBuilder.RenameTable(
                name: "Provincia",
                newName: "Provincias");

            migrationBuilder.RenameIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincias",
                newName: "IX_Provincias_PaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincias_ProvinciaId",
                table: "Localidad",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Pais_PaisId",
                table: "Provincias",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincias_ProvinciaId",
                table: "Localidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Pais_PaisId",
                table: "Provincias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Provincias",
                table: "Provincias");

            migrationBuilder.RenameTable(
                name: "Provincias",
                newName: "Provincia");

            migrationBuilder.RenameIndex(
                name: "IX_Provincias_PaisId",
                table: "Provincia",
                newName: "IX_Provincia_PaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Provincia",
                table: "Provincia",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaId",
                table: "Localidad",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincia_Pais_PaisId",
                table: "Provincia",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id");
        }
    }
}
