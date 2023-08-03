using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ligamania.Repository.Migrations
{
    /// <inheritdoc />
    public partial class arreglo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaPremiosPuesto");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaPremios");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaEquipo");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaContabilidad");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaCompeticionJornada");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "TemporadaClasificacion");

            //migrationBuilder.AddColumn<int>(
            //    name: "GolesExtraContra",
            //    table: "TemporadaClasificacion",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<int>(
            //    name: "GolesExtraFavor",
            //    table: "TemporadaClasificacion",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GolesExtraContra",
                table: "TemporadaClasificacion");

            migrationBuilder.DropColumn(
                name: "GolesExtraFavor",
                table: "TemporadaClasificacion");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaPremiosPuesto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaPremios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaEquipo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaContabilidad",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaCompeticionJornada",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TemporadaClasificacion",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
