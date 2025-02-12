using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class SucursalesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    EstudioId = table.Column<int>(type: "int", nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sucursales_Estudios_EstudioId",
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
                values: new object[] { new DateTime(2025, 2, 12, 10, 56, 3, 807, DateTimeKind.Local).AddTicks(5780), new DateTime(2025, 2, 12, 10, 56, 3, 807, DateTimeKind.Local).AddTicks(5820) });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_CiudadId",
                table: "Sucursales",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_EstudioId",
                table: "Sucursales",
                column: "EstudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 12, 6, 37, 58, 908, DateTimeKind.Local).AddTicks(5100), new DateTime(2025, 2, 12, 6, 37, 58, 908, DateTimeKind.Local).AddTicks(5130) });
        }
    }
}
