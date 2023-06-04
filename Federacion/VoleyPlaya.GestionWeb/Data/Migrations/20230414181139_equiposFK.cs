using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class equiposFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_dbo.EdicionCategoria_Id",
            //    table: "Ediciones");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_dbo.EdicionCompeticion_Id",
            //    table: "Ediciones");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_dbo.EdicionTemporada_Id",
            //    table: "Ediciones");

            //migrationBuilder.DropForeignKey(
            //    name: "Fk_dbo.EdicionGrupoEdicion_Id",
            //    table: "EdicionGrupos");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Equipos_EdicionGrupos_EdicionGrupoId",
            //    table: "Equipos");

            //migrationBuilder.DropForeignKey(
            //    name: "Fk_dbo.EdicionJornada_Id",
            //    table: "Jornada");

            //migrationBuilder.DropIndex(
            //    name: "IX_Equipo",
            //    table: "Equipos");

            //migrationBuilder.DropIndex(
            //    name: "IX_Equipos_EdicionId",
            //    table: "Equipos");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Equipo",
            //    table: "Equipos",
            //    columns: new[] { "EdicionId", "EdicionGrupoId", "Nombre" },
            //    unique: true,
            //    filter: "[EdicionId] IS NOT NULL AND [EdicionGrupoId] IS NOT NULL AND [Nombre] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_dbo.EdicionCategoria_Id",
            //    table: "Ediciones",
            //    column: "CategoriaId",
            //    principalTable: "Categorias",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_dbo.EdicionCompeticion_Id",
            //    table: "Ediciones",
            //    column: "CompeticionId",
            //    principalTable: "Competiciones",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_dbo.EdicionTemporada_Id",
            //    table: "Ediciones",
            //    column: "TemporadaId",
            //    principalTable: "Temporadas",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "Fk_dbo.EdicionGrupoEdicion_Id",
            //    table: "EdicionGrupos",
            //    column: "EdicionId",
            //    principalTable: "Ediciones",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_dbo.Equipo_dbo.EdicionGrupo_Id",
            //    table: "Equipos",
            //    column: "EdicionGrupoId",
            //    principalTable: "EdicionGrupos",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "Fk_dbo.EdicionJornada_Id",
            //    table: "Jornada",
            //    column: "EdicionId",
            //    principalTable: "Ediciones",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.EdicionCategoria_Id",
                table: "Ediciones");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.EdicionCompeticion_Id",
                table: "Ediciones");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.EdicionTemporada_Id",
                table: "Ediciones");

            migrationBuilder.DropForeignKey(
                name: "Fk_dbo.EdicionGrupoEdicion_Id",
                table: "EdicionGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Equipo_dbo.EdicionGrupo_Id",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "Fk_dbo.EdicionJornada_Id",
                table: "Jornada");

            migrationBuilder.DropIndex(
                name: "IX_Equipo",
                table: "Equipos");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo",
                table: "Equipos",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_EdicionId",
                table: "Equipos",
                column: "EdicionId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.EdicionCategoria_Id",
                table: "Ediciones",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.EdicionCompeticion_Id",
                table: "Ediciones",
                column: "CompeticionId",
                principalTable: "Competiciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.EdicionTemporada_Id",
                table: "Ediciones",
                column: "TemporadaId",
                principalTable: "Temporadas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Fk_dbo.EdicionGrupoEdicion_Id",
                table: "EdicionGrupos",
                column: "EdicionId",
                principalTable: "Ediciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_EdicionGrupos_EdicionGrupoId",
                table: "Equipos",
                column: "EdicionGrupoId",
                principalTable: "EdicionGrupos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Fk_dbo.EdicionJornada_Id",
                table: "Jornada",
                column: "EdicionId",
                principalTable: "Ediciones",
                principalColumn: "Id");
        }
    }
}
