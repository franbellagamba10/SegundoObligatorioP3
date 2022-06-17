using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class VariablesGlobalesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VariablesGlobales",
                columns: table => new
                {
                    IVA = table.Column<decimal>(nullable: false),
                    ImpuestoImportacion = table.Column<decimal>(nullable: false),
                    TasaArancelaria = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariablesGlobales");
        }
    }
}
