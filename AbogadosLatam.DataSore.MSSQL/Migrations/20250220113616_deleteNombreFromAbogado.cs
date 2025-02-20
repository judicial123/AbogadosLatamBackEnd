using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class deleteNombreFromAbogado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Abogados");

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 20, 6, 36, 16, 456, DateTimeKind.Local).AddTicks(8380), new DateTime(2025, 2, 20, 6, 36, 16, 456, DateTimeKind.Local).AddTicks(8430) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Abogados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 19, 15, 6, 18, 716, DateTimeKind.Local).AddTicks(1560), new DateTime(2025, 2, 19, 15, 6, 18, 716, DateTimeKind.Local).AddTicks(1600) });
        }
    }
}
