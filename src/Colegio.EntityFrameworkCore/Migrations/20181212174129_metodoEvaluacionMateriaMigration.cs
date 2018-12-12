using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class metodoEvaluacionMateriaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetodoEvaluacionId",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_MetodoEvaluacionId",
                table: "Materia",
                column: "MetodoEvaluacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_MetodoEvaluacion_MetodoEvaluacionId",
                table: "Materia",
                column: "MetodoEvaluacionId",
                principalTable: "MetodoEvaluacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_MetodoEvaluacion_MetodoEvaluacionId",
                table: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Materia_MetodoEvaluacionId",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "MetodoEvaluacionId",
                table: "Materia");
        }
    }
}
