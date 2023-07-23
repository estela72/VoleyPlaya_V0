using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ligamania.Repository.Migrations
{
    /// <inheritdoc />
    public partial class historico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "Historico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Nombre",
            //    table: "Historico",
            //    type: "nvarchar(max)",
            //    nullable: true);
        }
    }
}
