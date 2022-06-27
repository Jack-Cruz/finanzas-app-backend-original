using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bonistas",
                columns: table => new
                {
                    idbonista = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    celular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    contrasenia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RUC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    distrito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonistas", x => x.idbonista);
                });

            migrationBuilder.CreateTable(
                name: "BonoResumenes",
                columns: table => new
                {
                    idresumen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbono = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<double>(type: "float", nullable: false),
                    utilidad_perdida = table.Column<double>(type: "float", nullable: false),
                    TCEAemisor = table.Column<double>(type: "float", nullable: false),
                    TCEAemisorescudo = table.Column<double>(type: "float", nullable: false),
                    tirbonista = table.Column<double>(type: "float", nullable: false),
                    TREAbonista = table.Column<double>(type: "float", nullable: false),
                    duracion = table.Column<double>(type: "float", nullable: false),
                    duracionmod = table.Column<double>(type: "float", nullable: false),
                    convexidad = table.Column<double>(type: "float", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    moneda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonoResumenes", x => x.idresumen);
                });

            migrationBuilder.CreateTable(
                name: "Bonos",
                columns: table => new
                {
                    idbono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbonista = table.Column<int>(type: "int", nullable: false),
                    valnominal = table.Column<double>(type: "float", nullable: false),
                    valcomercial = table.Column<float>(type: "real", nullable: false),
                    moneda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anios = table.Column<int>(type: "int", nullable: false),
                    frecpago = table.Column<int>(type: "int", nullable: false),
                    capitalizacion = table.Column<int>(type: "int", nullable: false),
                    tipotasa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tasainteres = table.Column<double>(type: "float", nullable: false),
                    tasadescuento = table.Column<double>(type: "float", nullable: false),
                    imprenta = table.Column<double>(type: "float", nullable: false),
                    fecemision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    percprima = table.Column<double>(type: "float", nullable: false),
                    percflotacion = table.Column<double>(type: "float", nullable: false),
                    percestructuracion = table.Column<double>(type: "float", nullable: false),
                    perccolocacion = table.Column<double>(type: "float", nullable: false),
                    perccavali = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonos", x => x.idbono);
                });

            migrationBuilder.CreateTable(
                name: "Flujos",
                columns: table => new
                {
                    idflujo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idbono = table.Column<int>(type: "int", nullable: false),
                    n = table.Column<int>(type: "int", nullable: false),
                    bono = table.Column<double>(type: "float", nullable: false),
                    interes = table.Column<double>(type: "float", nullable: false),
                    cuota = table.Column<double>(type: "float", nullable: false),
                    amortizacion = table.Column<double>(type: "float", nullable: false),
                    prima = table.Column<double>(type: "float", nullable: false),
                    escudo = table.Column<double>(type: "float", nullable: false),
                    flujoemisor = table.Column<double>(type: "float", nullable: false),
                    flujoemisorescudo = table.Column<double>(type: "float", nullable: false),
                    flujobonista = table.Column<double>(type: "float", nullable: false),
                    flujoactual = table.Column<double>(type: "float", nullable: false),
                    faplazo = table.Column<double>(type: "float", nullable: false),
                    convexidad = table.Column<double>(type: "float", nullable: false)
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
