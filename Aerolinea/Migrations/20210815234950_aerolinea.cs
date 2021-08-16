using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aerolinea.Migrations
{
    public partial class aerolinea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    AeropuertoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoIata = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    Ciudad = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.AeropuertoID);
                });

            migrationBuilder.CreateTable(
                name: "ClaseTarifaria",
                columns: table => new
                {
                    ClaseTarifariaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    PrecioBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaseTarifaria", x => x.ClaseTarifariaID);
                });

            migrationBuilder.CreateTable(
                name: "Pasajero",
                columns: table => new
                {
                    PasajeroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDoc = table.Column<int>(type: "int", nullable: true),
                    NroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajero", x => x.PasajeroID);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    VueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraSalida = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    HoraLlegada = table.Column<TimeSpan>(type: "time(0)", nullable: true),
                    AeropuertoOrigen = table.Column<int>(type: "int", nullable: true),
                    AeropuertoDestino = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.VueloId);
                    table.ForeignKey(
                        name: "FK_Vuelo_Aeropuerto_Destino",
                        column: x => x.AeropuertoDestino,
                        principalTable: "Aeropuerto",
                        principalColumn: "AeropuertoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vuelo_Aeropuerto_Origen",
                        column: x => x.AeropuertoOrigen,
                        principalTable: "Aeropuerto",
                        principalColumn: "AeropuertoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReserva = table.Column<DateTime>(type: "datetime", nullable: true),
                    VueloIda = table.Column<int>(type: "int", nullable: true),
                    VueloRetorno = table.Column<int>(type: "int", nullable: true),
                    PasajeroID = table.Column<int>(type: "int", nullable: true),
                    ClaseTarifariaID = table.Column<int>(type: "int", nullable: true),
                    PrecioReservado = table.Column<decimal>(type: "smallmoney", nullable: true),
                    FechaIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVuelta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reserva_ClaseTarifaria",
                        column: x => x.ClaseTarifariaID,
                        principalTable: "ClaseTarifaria",
                        principalColumn: "ClaseTarifariaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Pasajero",
                        column: x => x.PasajeroID,
                        principalTable: "Pasajero",
                        principalColumn: "PasajeroID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Vuelo_Ida",
                        column: x => x.VueloIda,
                        principalTable: "Vuelo",
                        principalColumn: "VueloId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserva_Vuelo_Retorno",
                        column: x => x.VueloRetorno,
                        principalTable: "Vuelo",
                        principalColumn: "VueloId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClaseTarifariaID",
                table: "Reserva",
                column: "ClaseTarifariaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PasajeroID",
                table: "Reserva",
                column: "PasajeroID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VueloIda",
                table: "Reserva",
                column: "VueloIda");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VueloRetorno",
                table: "Reserva",
                column: "VueloRetorno");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_AeropuertoDestino",
                table: "Vuelo",
                column: "AeropuertoDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelo_AeropuertoOrigen",
                table: "Vuelo",
                column: "AeropuertoOrigen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "ClaseTarifaria");

            migrationBuilder.DropTable(
                name: "Pasajero");

            migrationBuilder.DropTable(
                name: "Vuelo");

            migrationBuilder.DropTable(
                name: "Aeropuerto");
        }
    }
}
