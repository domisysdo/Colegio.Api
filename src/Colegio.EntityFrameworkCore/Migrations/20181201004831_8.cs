using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "FamiliarEstudiante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamiliarEstudiante_EstudianteId",
                table: "FamiliarEstudiante",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliarEstudiante_Estudiante_EstudianteId",
                table: "FamiliarEstudiante",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamiliarEstudiante_Estudiante_EstudianteId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_FamiliarEstudiante_EstudianteId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "FamiliarEstudiante");
        }
    }
}
