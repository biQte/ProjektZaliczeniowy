using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektZaliczeniowy.Migrations
{
    /// <inheritdoc />
    public partial class Removedefaultseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "IsActive", "LastLogin", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, new DateTime(2025, 1, 10, 1, 44, 8, 106, DateTimeKind.Local).AddTicks(1904), true, null, "$2a$11$W3VMcQjRJP/cXEtTeU5NhuK0z9SWdzEhMCu7rXmSW3sm1bItl3tdC", "Admin", "admin" });
        }
    }
}
