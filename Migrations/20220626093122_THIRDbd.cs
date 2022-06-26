using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    public partial class THIRDbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TCEAbonista",
                table: "BonoResumenes",
                newName: "utilidad_perdida");

            migrationBuilder.AddColumn<double>(
                name: "TCEAemisorescudo",
                table: "BonoResumenes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TREAbonista",
                table: "BonoResumenes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "precio",
                table: "BonoResumenes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TCEAemisorescudo",
                table: "BonoResumenes");

            migrationBuilder.DropColumn(
                name: "TREAbonista",
                table: "BonoResumenes");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "BonoResumenes");

            migrationBuilder.RenameColumn(
                name: "utilidad_perdida",
                table: "BonoResumenes",
                newName: "TCEAbonista");
        }
    }
}
