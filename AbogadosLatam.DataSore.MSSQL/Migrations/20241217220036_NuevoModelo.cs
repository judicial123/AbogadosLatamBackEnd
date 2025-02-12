using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class NuevoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "DateCreated", "DateModified", "Nombre" },
                values: new object[] { 1, new DateTime(2024, 12, 17, 17, 0, 35, 559, DateTimeKind.Local).AddTicks(6190), new DateTime(2024, 12, 17, 17, 0, 35, 559, DateTimeKind.Local).AddTicks(6220), "Ecuador" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "DateCreated", "DateModified", "Nombre" },
                values: new object[] { 1, new DateTime(2024, 11, 25, 15, 39, 43, 82, DateTimeKind.Local).AddTicks(2000), new DateTime(2024, 11, 25, 15, 39, 43, 82, DateTimeKind.Local).AddTicks(2030), "Ecuador" });
        }
    }
}
