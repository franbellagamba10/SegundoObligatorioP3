using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class RelacionPlantaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
