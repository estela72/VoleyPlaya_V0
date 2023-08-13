using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ligamania.Repository.Migrations
{
    /// <inheritdoc />
    public partial class JugadorPendienteBaja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PendienteBaja",
                table: "Jugador",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PendienteBaja",
                table: "Jugador");
        }
    }
}
