using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finanzas_backend_app.Migrations
{
    public partial class secondbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flujos_Bonos_Bonoidbono",
                table: "Flujos");

            migrationBuilder.DropIndex(
                name: "IX_Flujos_Bonoidbono",
                table: "Flujos");

            migrationBuilder.DropColumn(
                name: "Bonoidbono",
                table: "Flujos");

            migrationBuilder.AddColumn<double>(
                name: "interes",
                table: "Flujos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "anios",
                table: "Bonos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "capitalizacion",
                table: "Bonos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "percflotacion",
                table: "Bonos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "idbono",
                table: "BonoResumenes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "interes",
                table: "Flujos");

            migrationBuilder.DropColumn(
                name: "capitalizacion",
                table: "Bonos");

            migrationBuilder.DropColumn(
                name: "percflotacion",
                table: "Bonos");

            migrationBuilder.DropColumn(
                name: "idbono",
                table: "BonoResumenes");

            migrationBuilder.AddColumn<int>(
                name: "Bonoidbono",
                table: "Flujos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "anios",
                table: "Bonos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Flujos_Bonoidbono",
                table: "Flujos",
                column: "Bonoidbono");

            migrationBuilder.AddForeignKey(
                name: "FK_Flujos_Bonos_Bonoidbono",
                table: "Flujos",
                column: "Bonoidbono",
                principalTable: "Bonos",
                principalColumn: "idbono");
        }
    }
}
