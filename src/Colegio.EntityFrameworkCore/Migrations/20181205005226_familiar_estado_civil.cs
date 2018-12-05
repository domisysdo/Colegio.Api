using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class familiar_estado_civil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoCivil",
                table: "FamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadId",
                table: "FamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                table: "FamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FamiliarEstudiante_NacionalidadId",
                table: "FamiliarEstudiante",
                column: "NacionalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliarEstudiante_Nacionalidad_NacionalidadId",
                table: "FamiliarEstudiante",
                column: "NacionalidadId",
                principalTable: "Nacionalidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamiliarEstudiante_Nacionalidad_NacionalidadId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_FamiliarEstudiante_NacionalidadId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "NacionalidadId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "FamiliarEstudiante");
        }
    }
}
