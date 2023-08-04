using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.Organization.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class equipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.RenameTable(
                name: "Equipo",
                newName: "Equipos");

            migrationBuilder.RenameIndex(
                name: "IX_Equipo_Nombre",
                table: "Equipos",
                newName: "IX_Equipos_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos");

            migrationBuilder.RenameTable(
                name: "Equipos",
                newName: "Equipo");

            migrationBuilder.RenameIndex(
                name: "IX_Equipos_Nombre",
                table: "Equipo",
                newName: "IX_Equipo_Nombre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "Id");
        }
    }
}
