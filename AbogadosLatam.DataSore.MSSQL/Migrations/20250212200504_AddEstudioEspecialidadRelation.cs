using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddEstudioEspecialidadRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstudioEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudioId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudioEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudioEspecialidades_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudioEspecialidades_Estudios_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 12, 15, 5, 3, 515, DateTimeKind.Local).AddTicks(2180), new DateTime(2025, 2, 12, 15, 5, 3, 515, DateTimeKind.Local).AddTicks(2220) });

            migrationBuilder.CreateIndex(
                name: "IX_EstudioEspecialidades_EspecialidadId",
                table: "EstudioEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudioEspecialidades_EstudioId",
                table: "EstudioEspecialidades",
                column: "EstudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudioEspecialidades");

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 12, 10, 56, 3, 807, DateTimeKind.Local).AddTicks(5780), new DateTime(2025, 2, 12, 10, 56, 3, 807, DateTimeKind.Local).AddTicks(5820) });
        }
    }
}
