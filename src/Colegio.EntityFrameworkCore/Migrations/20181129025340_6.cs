using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamiliarEstudiante_LugarTrabajo_LugarTrabajoId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropTable(
                name: "LugarTrabajo");

            migrationBuilder.DropIndex(
                name: "IX_FamiliarEstudiante_LugarTrabajoId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "LugarTrabajoId",
                table: "FamiliarEstudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LugarTrabajoId",
                table: "FamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LugarTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    SectorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LugarTrabajo_Sector_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sector",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamiliarEstudiante_LugarTrabajoId",
                table: "FamiliarEstudiante",
                column: "LugarTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_LugarTrabajo_SectorId",
                table: "LugarTrabajo",
                column: "SectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliarEstudiante_LugarTrabajo_LugarTrabajoId",
                table: "FamiliarEstudiante",
                column: "LugarTrabajoId",
                principalTable: "LugarTrabajo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
