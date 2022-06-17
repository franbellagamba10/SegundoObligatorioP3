using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class ItemsKeyCluster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Compras_Compraid",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "idPlanta",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "idCompra",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Compraid",
                table: "Items",
                newName: "CompraId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_Compraid",
                table: "Items",
                newName: "IX_Items_CompraId");

            migrationBuilder.AlterColumn<int>(
                name: "CompraId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantaId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                columns: new[] { "PlantaId", "CompraId" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Compras_CompraId",
                table: "Items",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Plantas_PlantaId",
                table: "Items",
                column: "PlantaId",
                principalTable: "Plantas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Compras_CompraId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Plantas_PlantaId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PlantaId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CompraId",
                table: "Items",
                newName: "Compraid");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CompraId",
                table: "Items",
                newName: "IX_Items_Compraid");

            migrationBuilder.AlterColumn<int>(
                name: "Compraid",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "idPlanta",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idCompra",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                columns: new[] { "idPlanta", "idCompra" });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Compras_Compraid",
                table: "Items",
                column: "Compraid",
                principalTable: "Compras",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
