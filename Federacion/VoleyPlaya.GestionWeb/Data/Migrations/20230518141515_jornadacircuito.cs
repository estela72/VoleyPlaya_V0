using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class jornadacircuito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Jornada",
                table: "Tablas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jornada",
                table: "Tablas");
        }
    }
}
