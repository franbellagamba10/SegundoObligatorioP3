using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class CorreccionModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_FrecuenciasRiego_frecuenciaRiegoid",
                table: "Fichas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_TiposIluminacion_tipoIluminacionid",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "idFrecuenciaRiego",
                table: "Fichas");

            migrationBuilder.DropColumn(
                name: "idTipoIluminacion",
                table: "Fichas");

            migrationBuilder.RenameColumn(
                name: "tipoIluminacionid",
                table: "Fichas",
                newName: "tipoIluminacionId");

            migrationBuilder.RenameColumn(
                name: "frecuenciaRiegoid",
                table: "Fichas",
                newName: "frecuenciaRiegoId");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_tipoIluminacionid",
                table: "Fichas",
                newName: "IX_Fichas_tipoIluminacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_frecuenciaRiegoid",
                table: "Fichas",
                newName: "IX_Fichas_frecuenciaRiegoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_FrecuenciasRiego_frecuenciaRiegoId",
                table: "Fichas",
                column: "frecuenciaRiegoId",
                principalTable: "FrecuenciasRiego",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_TiposIluminacion_tipoIluminacionId",
                table: "Fichas",
                column: "tipoIluminacionId",
                principalTable: "TiposIluminacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_FrecuenciasRiego_frecuenciaRiegoId",
                table: "Fichas");

            migrationBuilder.DropForeignKey(
                name: "FK_Fichas_TiposIluminacion_tipoIluminacionId",
                table: "Fichas");

            migrationBuilder.RenameColumn(
                name: "tipoIluminacionId",
                table: "Fichas",
                newName: "tipoIluminacionid");

            migrationBuilder.RenameColumn(
                name: "frecuenciaRiegoId",
                table: "Fichas",
                newName: "frecuenciaRiegoid");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_tipoIluminacionId",
                table: "Fichas",
                newName: "IX_Fichas_tipoIluminacionid");

            migrationBuilder.RenameIndex(
                name: "IX_Fichas_frecuenciaRiegoId",
                table: "Fichas",
                newName: "IX_Fichas_frecuenciaRiegoid");

            migrationBuilder.AddColumn<int>(
                name: "idFrecuenciaRiego",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idTipoIluminacion",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_FrecuenciasRiego_frecuenciaRiegoid",
                table: "Fichas",
                column: "frecuenciaRiegoid",
                principalTable: "FrecuenciasRiego",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fichas_TiposIluminacion_tipoIluminacionid",
                table: "Fichas",
                column: "tipoIluminacionid",
                principalTable: "TiposIluminacion",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
