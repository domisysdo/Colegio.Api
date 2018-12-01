using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Municipio_MunicipioId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Pais_PaisId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Provincia_ProvinciaId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFamiliarEstudiantes_FamiliarEstudiante_FamiliarEstudian~",
                table: "EmailFamiliarEstudiantes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFamiliarEstudiantes_TipoEmail_TipoEmailId",
                table: "EmailFamiliarEstudiantes");

            migrationBuilder.DropIndex(
                name: "IX_DireccionFamiliarEstudiante_MunicipioId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_DireccionFamiliarEstudiante_PaisId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_DireccionFamiliarEstudiante_ProvinciaId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailFamiliarEstudiantes",
                table: "EmailFamiliarEstudiantes");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "DireccionFamiliarEstudiante");

            migrationBuilder.RenameTable(
                name: "EmailFamiliarEstudiantes",
                newName: "EmailFamiliarEstudiante");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFamiliarEstudiantes_TipoEmailId",
                table: "EmailFamiliarEstudiante",
                newName: "IX_EmailFamiliarEstudiante_TipoEmailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFamiliarEstudiantes_FamiliarEstudianteId",
                table: "EmailFamiliarEstudiante",
                newName: "IX_EmailFamiliarEstudiante_FamiliarEstudianteId");

            migrationBuilder.AddColumn<int>(
                name: "TipoPadecimientoId",
                table: "Padecimiento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailFamiliarEstudiante",
                table: "EmailFamiliarEstudiante",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Padecimiento_TipoPadecimientoId",
                table: "Padecimiento",
                column: "TipoPadecimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFamiliarEstudiante_FamiliarEstudiante_FamiliarEstudiant~",
                table: "EmailFamiliarEstudiante",
                column: "FamiliarEstudianteId",
                principalTable: "FamiliarEstudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFamiliarEstudiante_TipoEmail_TipoEmailId",
                table: "EmailFamiliarEstudiante",
                column: "TipoEmailId",
                principalTable: "TipoEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Padecimiento_TipoPadecimiento_TipoPadecimientoId",
                table: "Padecimiento",
                column: "TipoPadecimientoId",
                principalTable: "TipoPadecimiento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailFamiliarEstudiante_FamiliarEstudiante_FamiliarEstudiant~",
                table: "EmailFamiliarEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailFamiliarEstudiante_TipoEmail_TipoEmailId",
                table: "EmailFamiliarEstudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_Padecimiento_TipoPadecimiento_TipoPadecimientoId",
                table: "Padecimiento");

            migrationBuilder.DropIndex(
                name: "IX_Padecimiento_TipoPadecimientoId",
                table: "Padecimiento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailFamiliarEstudiante",
                table: "EmailFamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "TipoPadecimientoId",
                table: "Padecimiento");

            migrationBuilder.RenameTable(
                name: "EmailFamiliarEstudiante",
                newName: "EmailFamiliarEstudiantes");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFamiliarEstudiante_TipoEmailId",
                table: "EmailFamiliarEstudiantes",
                newName: "IX_EmailFamiliarEstudiantes_TipoEmailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailFamiliarEstudiante_FamiliarEstudianteId",
                table: "EmailFamiliarEstudiantes",
                newName: "IX_EmailFamiliarEstudiantes_FamiliarEstudianteId");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "DireccionFamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "DireccionFamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "DireccionFamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailFamiliarEstudiantes",
                table: "EmailFamiliarEstudiantes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionFamiliarEstudiante_MunicipioId",
                table: "DireccionFamiliarEstudiante",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionFamiliarEstudiante_PaisId",
                table: "DireccionFamiliarEstudiante",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionFamiliarEstudiante_ProvinciaId",
                table: "DireccionFamiliarEstudiante",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Municipio_MunicipioId",
                table: "DireccionFamiliarEstudiante",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Pais_PaisId",
                table: "DireccionFamiliarEstudiante",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DireccionFamiliarEstudiante_Provincia_ProvinciaId",
                table: "DireccionFamiliarEstudiante",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFamiliarEstudiantes_FamiliarEstudiante_FamiliarEstudian~",
                table: "EmailFamiliarEstudiantes",
                column: "FamiliarEstudianteId",
                principalTable: "FamiliarEstudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailFamiliarEstudiantes_TipoEmail_TipoEmailId",
                table: "EmailFamiliarEstudiantes",
                column: "TipoEmailId",
                principalTable: "TipoEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
