using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class rondaActiva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "Activa",
            //    table: "TemporadaRonda",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "JornadaIdaActiva",
            //    table: "TemporadaRonda",
            //    nullable: false,
            //    defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activa",
                table: "TemporadaRonda");

            migrationBuilder.DropColumn(
                name: "JornadaIdaActiva",
                table: "TemporadaRonda");
        }
    }
}
