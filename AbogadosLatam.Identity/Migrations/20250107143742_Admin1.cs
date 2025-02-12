using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbogadosLatam.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Admin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "834c2d0a-80f3-4537-a015-f24958460b4e", "admin@admin.com", "admin@admin.com", "admin@admin.com", "AQAAAAIAAYagAAAAEP36cOWaV2XrmJWQpXw2UI44I0EtFW43ABg1qBs0mQShGXe9qm63K6Rj+Fd9W26IXQ==", "aa95008e-b962-437a-b21b-aaf8c2551346", "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11a9dd79-df85-4359-9ade-6ed65750a8d2", "AQAAAAIAAYagAAAAEMapfTy8to86r1J5O/BRNWLMxPgEZnoMVp4lU3TTNxmVSCwxSVSX3W5eOvJK9uDshA==", "8385975d-10d1-447f-856e-94c305d25d4a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6cf1f72f-9f7c-4621-9f1d-91dba78441d4", "admin@localhost.com", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMW4eBKy38YfdPWUiurbPwPvnSYrtsN+dLvJfOW2YIaEgn/RpfSpkwJJUS6qQAsKKg==", "6dca5aa8-892e-47ab-aa8c-08c738d511b0", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2ba4f1a-d5d1-4f88-b7a4-be1b0defe1f7", "AQAAAAIAAYagAAAAEG6H+k+JiYk8w7LjQFNWSGZ81J+DeAQXeLPAsXwiNHMVMYgTBwOVioNbDOm9i+YsfA==", "37faec06-cf3e-4b0f-b66c-f88886c8183f" });
        }
    }
}
