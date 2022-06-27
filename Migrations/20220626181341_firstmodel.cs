using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    public partial class firstmodel : Migration
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
                    idbono = table.Column<int>(type: "INTEGER", nullable: false),
                    precio = table.Column<double>(type: "REAL", nullable: false),
                    utilidad_perdida = table.Column<double>(type: "REAL", nullable: false),
                    TCEAemisor = table.Column<double>(type: "REAL", nullable: false),
                    TCEAemisorescudo = table.Column<double>(type: "REAL", nullable: false),
                    tirbonista = table.Column<double>(type: "REAL", nullable: false),
                    TREAbonista = table.Column<double>(type: "REAL", nullable: false),
                    duracion = table.Column<double>(type: "REAL", nullable: false),
                    duracionmod = table.Column<double>(type: "REAL", nullable: false),
                    convexidad = table.Column<double>(type: "REAL", nullable: false),
                    total = table.Column<double>(type: "REAL", nullable: false),
                    moneda = table.Column<string>(type: "TEXT", nullable: true)
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
                    valnominal = table.Column<double>(type: "REAL", nullable: false),
                    valcomercial = table.Column<float>(type: "REAL", nullable: false),
                    moneda = table.Column<string>(type: "TEXT", nullable: true),
                    anios = table.Column<int>(type: "INTEGER", nullable: false),
                    frecpago = table.Column<int>(type: "INTEGER", nullable: false),
                    capitalizacion = table.Column<int>(type: "INTEGER", nullable: false),
                    tipotasa = table.Column<string>(type: "TEXT", nullable: true),
                    tasainteres = table.Column<double>(type: "REAL", nullable: false),
                    tasadescuento = table.Column<double>(type: "REAL", nullable: false),
                    imprenta = table.Column<double>(type: "REAL", nullable: false),
                    fecemision = table.Column<DateTime>(type: "TEXT", nullable: true),
                    percprima = table.Column<double>(type: "REAL", nullable: false),
                    percflotacion = table.Column<double>(type: "REAL", nullable: false),
                    percestructuracion = table.Column<double>(type: "REAL", nullable: false),
                    perccolocacion = table.Column<double>(type: "REAL", nullable: false),
                    perccavali = table.Column<double>(type: "REAL", nullable: false)
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
                    bono = table.Column<double>(type: "REAL", nullable: false),
                    interes = table.Column<double>(type: "REAL", nullable: false),
                    cuota = table.Column<double>(type: "REAL", nullable: false),
                    amortizacion = table.Column<double>(type: "REAL", nullable: false),
                    prima = table.Column<double>(type: "REAL", nullable: false),
                    escudo = table.Column<double>(type: "REAL", nullable: false),
                    flujoemisor = table.Column<double>(type: "REAL", nullable: false),
                    flujoemisorescudo = table.Column<double>(type: "REAL", nullable: false),
                    flujobonista = table.Column<double>(type: "REAL", nullable: false),
                    flujoactual = table.Column<double>(type: "REAL", nullable: false),
                    faplazo = table.Column<double>(type: "REAL", nullable: false),
                    convexidad = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flujos", x => x.idflujo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonistas");

            migrationBuilder.DropTable(
                name: "BonoResumenes");

            migrationBuilder.DropTable(
                name: "Bonos");

            migrationBuilder.DropTable(
                name: "Flujos");
        }
    }
}
