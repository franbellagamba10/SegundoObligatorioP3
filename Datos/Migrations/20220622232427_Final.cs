using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Fichas_FichaId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TiposPlanta_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Fichas_FichaId",
                table: "Plantas",
                column: "FichaId",
                principalTable: "Fichas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TiposPlanta_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TiposPlanta",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Plantas_Fichas_FichaId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_TiposPlanta_TipoPlantaId",
                table: "Plantas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantas_Usuarios_UsuarioId",
                table: "Plantas");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_Fichas_FichaId",
                table: "Plantas",
                column: "FichaId",
                principalTable: "Fichas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantas_TiposPlanta_TipoPlantaId",
                table: "Plantas",
                column: "TipoPlantaId",
                principalTable: "TiposPlanta",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
