using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class EstudiosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 12, 6, 35, 56, 90, DateTimeKind.Local).AddTicks(7390), new DateTime(2025, 2, 12, 6, 35, 56, 90, DateTimeKind.Local).AddTicks(7420) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 11, 16, 18, 19, 380, DateTimeKind.Local).AddTicks(1890), new DateTime(2025, 2, 11, 16, 18, 19, 380, DateTimeKind.Local).AddTicks(1930) });
        }
    }
}
