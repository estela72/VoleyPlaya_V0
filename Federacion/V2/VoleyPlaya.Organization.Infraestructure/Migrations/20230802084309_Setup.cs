using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.Organization.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competiciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competiciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdicionId = table.Column<int>(type: "int", nullable: true),
                    OrdenCalendario = table.Column<int>(type: "int", nullable: true),
                    Jugados = table.Column<int>(type: "int", nullable: true),
                    Ganados = table.Column<int>(type: "int", nullable: true),
                    Perdidos = table.Column<int>(type: "int", nullable: true),
                    PuntosFavor = table.Column<int>(type: "int", nullable: true),
                    PuntosContra = table.Column<int>(type: "int", nullable: true),
                    Coeficiente = table.Column<double>(type: "float", nullable: true),
                    Puntos = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Retirado = table.Column<bool>(type: "bit", nullable: true),
                    OrdenEntrada = table.Column<int>(type: "int", nullable: true),
                    ClasificacionFinal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.Id);
                });

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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Jornada = table.Column<int>(type: "int", nullable: false),
                    NumGrupos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tablas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Actual = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria",
                table: "Categorias",
                column: "Nombre",
                unique: true,
                filter: "([Nombre] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Competicion",
                table: "Competiciones",
                column: "Nombre",
                unique: true,
                filter: "([Nombre] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo",
                table: "Equipo",
                columns: new[] { "EdicionId", "Nombre" },
                unique: true,
                filter: "([EdicionId] IS NOT NULL AND [Nombre] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Temporada",
                table: "Temporadas",
                column: "Nombre",
                unique: true,
                filter: "([Nombre] IS NOT NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Competiciones");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Tablas");

            migrationBuilder.DropTable(
                name: "Temporadas");
        }
    }
}
