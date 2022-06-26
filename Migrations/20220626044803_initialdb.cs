using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    public partial class initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonistas",
                columns: table => new
                {
                    idbonista = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DNI = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    correo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    celular = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    usuario = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    contrasenia = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RUC = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    provincia = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    distrito = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonistas", x => x.idbonista);
                });

            migrationBuilder.CreateTable(
                name: "BonoResumenes",
                columns: table => new
                {
                    idresumen = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TCEAemisor = table.Column<float>(type: "REAL", nullable: false),
                    TCEAbonista = table.Column<float>(type: "REAL", nullable: false),
                    duracion = table.Column<float>(type: "REAL", nullable: false),
                    duracionmod = table.Column<float>(type: "REAL", nullable: false),
                    convexidad = table.Column<float>(type: "REAL", nullable: false),
                    total = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonoResumenes", x => x.idresumen);
                });

            migrationBuilder.CreateTable(
                name: "Bonos",
                columns: table => new
                {
                    idbono = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idbonista = table.Column<int>(type: "INTEGER", nullable: false),
                    valnominal = table.Column<float>(type: "REAL", nullable: false),
                    valcomercial = table.Column<float>(type: "REAL", nullable: false),
                    moneda = table.Column<string>(type: "TEXT", nullable: true),
                    anios = table.Column<int>(type: "INTEGER", nullable: true),
                    frecpago = table.Column<int>(type: "INTEGER", nullable: false),
                    tipotasa = table.Column<string>(type: "TEXT", nullable: true),
                    tasainteres = table.Column<float>(type: "REAL", nullable: false),
                    tasadescuento = table.Column<float>(type: "REAL", nullable: false),
                    imprenta = table.Column<float>(type: "REAL", nullable: false),
                    fecemision = table.Column<DateTime>(type: "TEXT", nullable: true),
                    percprima = table.Column<float>(type: "REAL", nullable: false),
                    percestructuracion = table.Column<float>(type: "REAL", nullable: false),
                    perccolocacion = table.Column<float>(type: "REAL", nullable: false),
                    perccavali = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonos", x => x.idbono);
                });

            migrationBuilder.CreateTable(
                name: "Flujos",
                columns: table => new
                {
                    idflujo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idbono = table.Column<int>(type: "INTEGER", nullable: false),
                    n = table.Column<int>(type: "INTEGER", nullable: false),
                    bono = table.Column<float>(type: "REAL", nullable: false),
                    cuota = table.Column<float>(type: "REAL", nullable: false),
                    amortizacion = table.Column<float>(type: "REAL", nullable: false),
                    prima = table.Column<float>(type: "REAL", nullable: false),
                    escudo = table.Column<float>(type: "REAL", nullable: false),
                    flujoemisor = table.Column<float>(type: "REAL", nullable: false),
                    flujoemisorescudo = table.Column<float>(type: "REAL", nullable: false),
                    flujobonista = table.Column<float>(type: "REAL", nullable: false),
                    flujoactual = table.Column<float>(type: "REAL", nullable: false),
                    faplazo = table.Column<float>(type: "REAL", nullable: false),
                    convexidad = table.Column<float>(type: "REAL", nullable: false),
                    Bonoidbono = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flujos", x => x.idflujo);
                    table.ForeignKey(
                        name: "FK_Flujos_Bonos_Bonoidbono",
                        column: x => x.Bonoidbono,
                        principalTable: "Bonos",
                        principalColumn: "idbono");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Bonoidbono",
                table: "Flujos",
                column: "Bonoidbono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonistas");

            migrationBuilder.DropTable(
                name: "BonoResumenes");

            migrationBuilder.DropTable(
                name: "Flujos");

            migrationBuilder.DropTable(
                name: "Bonos");
        }
    }
}
