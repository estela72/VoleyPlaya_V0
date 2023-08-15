using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class numGrupos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumGrupos",
                table: "Tablas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumGrupos",
                table: "Tablas");
        }
    }
}
