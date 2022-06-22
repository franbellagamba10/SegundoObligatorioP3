using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class CompraModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "costoTotal",
                table: "Compras",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costoTotal",
                table: "Compras");
        }
    }
}
