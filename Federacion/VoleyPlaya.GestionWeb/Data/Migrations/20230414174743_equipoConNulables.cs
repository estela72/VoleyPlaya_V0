﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class equipoConNulables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EdicionId",
                table: "Equipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EdicionId",
                table: "Equipos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
