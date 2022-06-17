using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class ComprasHerenciaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "impuestoImportacion",
                table: "Compras",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "tasaArancelaria",
                table: "Compras",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "impuestoImportacion",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "tasaArancelaria",
                table: "Compras");
        }
    }
}
