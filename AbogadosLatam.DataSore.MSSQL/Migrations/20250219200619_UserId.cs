using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.DataSore.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abogados_ApplicationUser_UsuarioId",
                table: "Abogados");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Abogados",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Abogados_ApplicationUser_UsuarioId",
                table: "Abogados",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abogados_ApplicationUser_UsuarioId",
                table: "Abogados");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Abogados");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Abogados",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2025, 2, 13, 15, 36, 32, 874, DateTimeKind.Local).AddTicks(3450), new DateTime(2025, 2, 13, 15, 36, 32, 874, DateTimeKind.Local).AddTicks(3490) });

            migrationBuilder.AddForeignKey(
                name: "FK_Abogados_ApplicationUser_UsuarioId",
                table: "Abogados",
                column: "UsuarioId",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
