using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ligamania.Repository.Migrations
{
    /// <inheritdoc />
    public partial class historificada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Historificada",
                table: "Temporada",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Historificada",
                table: "Temporada");
        }
    }
}
