﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    esSudamericana = table.Column<bool>(nullable: true),
                    medidasSanitarias = table.Column<string>(nullable: true),
                    IVA = table.Column<decimal>(nullable: true),
                    cobroFlete = table.Column<bool>(nullable: true),
                    costoEnvio = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciasRiego",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tiempo = table.Column<string>(maxLength: 20, nullable: false),
                    cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrecuenciasRiego", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposIluminacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iluminacion = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposIluminacion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlanta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlanta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    contrasenia = table.Column<string>(maxLength: 20, nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    idPlanta = table.Column<int>(nullable: false),
                    idCompra = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    precioUnidad = table.Column<decimal>(nullable: false),
                    Compraid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => new { x.idPlanta, x.idCompra });
                    table.ForeignKey(
                        name: "FK_Items_Compras_Compraid",
                        column: x => x.Compraid,
                        principalTable: "Compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    frecuenciaRiegoid = table.Column<int>(nullable: false),
                    tipoIluminacionid = table.Column<int>(nullable: false),
                    temperatura = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Fichas_FrecuenciasRiego_frecuenciaRiegoid",
                        column: x => x.frecuenciaRiegoid,
                        principalTable: "FrecuenciasRiego",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fichas_TiposIluminacion_tipoIluminacionid",
                        column: x => x.tipoIluminacionid,
                        principalTable: "TiposIluminacion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoid = table.Column<int>(nullable: false),
                    nombreCientifico = table.Column<string>(nullable: false),
                    nombresVulgares = table.Column<string>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: false),
                    ambiente = table.Column<int>(nullable: false),
                    alturaMaxima = table.Column<int>(nullable: false),
                    foto = table.Column<string>(nullable: true),
                    precio = table.Column<decimal>(nullable: false),
                    ingresadoPorid = table.Column<int>(nullable: true),
                    fichaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plantas_Fichas_fichaid",
                        column: x => x.fichaid,
                        principalTable: "Fichas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plantas_Usuarios_ingresadoPorid",
                        column: x => x.ingresadoPorid,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plantas_TiposPlanta_tipoid",
                        column: x => x.tipoid,
                        principalTable: "TiposPlanta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_frecuenciaRiegoid",
                table: "Fichas",
                column: "frecuenciaRiegoid");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_tipoIluminacionid",
                table: "Fichas",
                column: "tipoIluminacionid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Compraid",
                table: "Items",
                column: "Compraid");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_fichaid",
                table: "Plantas",
                column: "fichaid");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_ingresadoPorid",
                table: "Plantas",
                column: "ingresadoPorid");

            migrationBuilder.CreateIndex(
                name: "IX_Plantas_tipoid",
                table: "Plantas",
                column: "tipoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Plantas");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposPlanta");

            migrationBuilder.DropTable(
                name: "FrecuenciasRiego");

            migrationBuilder.DropTable(
                name: "TiposIluminacion");
        }
    }
}