using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Migrations
{
    public partial class merge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MontoPago",
                table: "Cuota",
                newName: "Balance");

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    InscripcionId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagoDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    PagoId = table.Column<int>(nullable: false),
                    CuotaId = table.Column<int>(nullable: false),
                    MontoPago = table.Column<decimal>(nullable: false),
                    MontoMoraPago = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagoDetalle_Cuota_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "Cuota",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoDetalle_Pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pago_InscripcionId",
                table: "Pago",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalle_CuotaId",
                table: "PagoDetalle",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalle_PagoId",
                table: "PagoDetalle",
                column: "PagoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagoDetalle");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Cuota",
                newName: "MontoPago");
        }
    }
}
