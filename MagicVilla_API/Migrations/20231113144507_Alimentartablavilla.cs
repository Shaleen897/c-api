using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class Alimentartablavilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "villas",
                columns: new[] { "Id", "Amenidad", "Detalle", "FechaActualizacion", "FechaCrecion", "ImgURL", "MetrosCuadrados", "Name", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "", "Detalle de la Villa....", new DateTime(2023, 11, 13, 10, 45, 7, 225, DateTimeKind.Local).AddTicks(3302), new DateTime(2023, 11, 13, 10, 45, 7, 225, DateTimeKind.Local).AddTicks(3288), "", 50, "Villa Real", 5, 500.0 },
                    { 2, "", "Detalle de la Villa Gi....", new DateTime(2023, 11, 13, 10, 45, 7, 225, DateTimeKind.Local).AddTicks(3306), new DateTime(2023, 11, 13, 10, 45, 7, 225, DateTimeKind.Local).AddTicks(3305), "", 40, "Premium Villa Gi", 4, 150.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
