using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.GestionWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeloCompeticion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ModeloCompeticion",
                table: "Ediciones",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModeloCompeticion",
                table: "Ediciones");
        }
    }
}
