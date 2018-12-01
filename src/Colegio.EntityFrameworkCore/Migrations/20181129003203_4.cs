using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DireccionEstudiante_Municipio_MunicipioId",
                table: "DireccionEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_DireccionEstudiante_Pais_PaisId",
                table: "DireccionEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_DireccionEstudiante_Provincia_ProvinciaId",
                table: "DireccionEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_DireccionEstudiante_MunicipioId",
                table: "DireccionEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_DireccionEstudiante_PaisId",
                table: "DireccionEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_DireccionEstudiante_ProvinciaId",
                table: "DireccionEstudiante");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "DireccionEstudiante");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "DireccionEstudiante");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "DireccionEstudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "DireccionEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "DireccionEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "DireccionEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DireccionEstudiante_MunicipioId",
                table: "DireccionEstudiante",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionEstudiante_PaisId",
                table: "DireccionEstudiante",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionEstudiante_ProvinciaId",
                table: "DireccionEstudiante",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionEstudiante_Municipio_MunicipioId",
                table: "DireccionEstudiante",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionEstudiante_Pais_PaisId",
                table: "DireccionEstudiante",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionEstudiante_Provincia_ProvinciaId",
                table: "DireccionEstudiante",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
