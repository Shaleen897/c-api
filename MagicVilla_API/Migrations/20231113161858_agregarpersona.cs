using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class agregarpersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "persona",
                columns: new[] { "Id", "FechaActualizacion", "FechaCrecion", "Name", "lastName" },
                values: new object[] { 1, new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(4888), new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(4870), "Giul", "anto" });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCrecion" },
                values: new object[] { new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(5185), new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCrecion" },
                values: new object[] { new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(5189), new DateTime(2023, 11, 13, 12, 18, 58, 440, DateTimeKind.Local).AddTicks(5188) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "persona",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCrecion" },
                values: new object[] { new DateTime(2023, 11, 13, 12, 16, 17, 242, DateTimeKind.Local).AddTicks(4377), new DateTime(2023, 11, 13, 12, 16, 17, 242, DateTimeKind.Local).AddTicks(4359) });

            migrationBuilder.UpdateData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCrecion" },
                values: new object[] { new DateTime(2023, 11, 13, 12, 16, 17, 242, DateTimeKind.Local).AddTicks(4381), new DateTime(2023, 11, 13, 12, 16, 17, 242, DateTimeKind.Local).AddTicks(4381) });
        }
    }
}
