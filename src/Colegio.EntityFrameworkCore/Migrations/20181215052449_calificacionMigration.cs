using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class calificacionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    EstudianteId = table.Column<int>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false),
                    MateriaId = table.Column<int>(nullable: false),
                    DetalleMetodoEvaluacionId = table.Column<int>(nullable: false),
                    Puntuacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificacion_DetalleMetodoEvaluacion_DetalleMetodoEvaluacion~",
                        column: x => x.DetalleMetodoEvaluacionId,
                        principalTable: "DetalleMetodoEvaluacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_DetalleMetodoEvaluacionId",
                table: "Calificacion",
                column: "DetalleMetodoEvaluacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_EstudianteId",
                table: "Calificacion",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_GrupoId",
                table: "Calificacion",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_MateriaId",
                table: "Calificacion",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificacion");
        }
    }
}
