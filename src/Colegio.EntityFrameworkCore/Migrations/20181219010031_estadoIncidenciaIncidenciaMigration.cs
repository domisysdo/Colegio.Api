using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class estadoIncidenciaIncidenciaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoIncidenciaId",
                table: "IncidenciaEstudiante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciaEstudiante_EstadoIncidenciaId",
                table: "IncidenciaEstudiante",
                column: "EstadoIncidenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidenciaEstudiante_EstadoIncidencia_EstadoIncidenciaId",
                table: "IncidenciaEstudiante",
                column: "EstadoIncidenciaId",
                principalTable: "EstadoIncidencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidenciaEstudiante_EstadoIncidencia_EstadoIncidenciaId",
                table: "IncidenciaEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_IncidenciaEstudiante_EstadoIncidenciaId",
                table: "IncidenciaEstudiante");

            migrationBuilder.DropColumn(
                name: "EstadoIncidenciaId",
                table: "IncidenciaEstudiante");
        }
    }
}
