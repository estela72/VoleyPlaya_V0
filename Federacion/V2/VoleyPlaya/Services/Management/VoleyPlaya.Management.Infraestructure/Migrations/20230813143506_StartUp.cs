using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class StartUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ediciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemporadaId = table.Column<int>(type: "int", nullable: false),
                    CompeticionId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TipoCalendario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModeloCompeticion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prueba = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ediciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EdicionGrupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdicionId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EdicionGrupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EdicionGrupos_Ediciones_EdicionId",
                        column: x => x.EdicionId,
                        principalTable: "Ediciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EdicionId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jornada_Ediciones_EdicionId",
                        column: x => x.EdicionId,
                        principalTable: "Ediciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdicionGrupoId = table.Column<int>(type: "int", nullable: false),
                    EquipoLocalId = table.Column<int>(type: "int", nullable: true),
                    EquipoVisitanteId = table.Column<int>(type: "int", nullable: true),
                    ResultadoLocal = table.Column<int>(type: "int", nullable: true),
                    ResultadoVisitante = table.Column<int>(type: "int", nullable: true),
                    Jornada = table.Column<int>(type: "int", nullable: true),
                    NumPartido = table.Column<int>(type: "int", nullable: true),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Validado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    NombreLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreVisitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ronda = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    ConResultado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    UserResultado = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    UserValidador = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValueSql: "(N'')"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidos_EdicionGrupos_EdicionGrupoId",
                        column: x => x.EdicionGrupoId,
                        principalTable: "EdicionGrupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parcial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidoId = table.Column<int>(type: "int", nullable: false),
                    ResultadoLocal = table.Column<int>(type: "int", nullable: true),
                    ResultadoVisitante = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parcial_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ediciones_CategoriaId",
                table: "Ediciones",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ediciones_CompeticionId",
                table: "Ediciones",
                column: "CompeticionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ediciones_Nombre",
                table: "Ediciones",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ediciones_TemporadaId_CompeticionId_CategoriaId_Genero_Prueba",
                table: "Ediciones",
                columns: new[] { "TemporadaId", "CompeticionId", "CategoriaId", "Genero", "Prueba" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EdicionGrupos_EdicionId_Nombre",
                table: "EdicionGrupos",
                columns: new[] { "EdicionId", "Nombre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_EdicionId",
                table: "Jornada",
                column: "EdicionId");

            migrationBuilder.CreateIndex(
                name: "IX_Parcial_PartidoId",
                table: "Parcial",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EdicionGrupoId",
                table: "Partidos",
                column: "EdicionGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoLocalId",
                table: "Partidos",
                column: "EquipoLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_EquipoVisitanteId",
                table: "Partidos",
                column: "EquipoVisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Label",
                table: "Partidos",
                column: "Label",
                unique: true,
                filter: "[Label] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.DropTable(
                name: "Parcial");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "EdicionGrupos");

            migrationBuilder.DropTable(
                name: "Ediciones");
        }
    }
}
