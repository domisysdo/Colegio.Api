using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class profesorMateriaMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfesorMateriaId",
                table: "ProfesorMateria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorMateriaId",
                table: "ProfesorMateria",
                nullable: false,
                defaultValue: 0);
        }
    }
}
