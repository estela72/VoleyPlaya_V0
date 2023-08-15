using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class tablasCalendarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tablas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumEquipos = table.Column<int>(type: "int", nullable: false),
                    NumPartido = table.Column<int>(type: "int", nullable: false),
                    Ronda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipo1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipo2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tablas");
        }
    }
}
