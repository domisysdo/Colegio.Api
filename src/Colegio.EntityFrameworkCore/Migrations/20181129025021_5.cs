using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentescoId",
                table: "FamiliarEstudiante",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FamiliarEstudiante_ParentescoId",
                table: "FamiliarEstudiante",
                column: "ParentescoId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamiliarEstudiante_Parentesco_ParentescoId",
                table: "FamiliarEstudiante",
                column: "ParentescoId",
                principalTable: "Parentesco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamiliarEstudiante_Parentesco_ParentescoId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_FamiliarEstudiante_ParentescoId",
                table: "FamiliarEstudiante");

            migrationBuilder.DropColumn(
                name: "ParentescoId",
                table: "FamiliarEstudiante");
        }
    }
}
