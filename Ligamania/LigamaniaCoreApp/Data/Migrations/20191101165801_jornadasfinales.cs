using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class jornadasfinales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "RondaId",
            //    table: "TemporadaCompeticionJornada",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemporadaCompeticionJornada_RondaId",
            //    table: "TemporadaCompeticionJornada",
            //    column: "RondaId");

            ////migrationBuilder.AddForeignKey(
            ////    name: "FK_dbo.TemporadaCompeticionJornadaIda_dbo.TemporadaRonda_RondaId",
            ////    table: "TemporadaCompeticionJornada",
            ////    column: "RondaId",
            ////    principalTable: "TemporadaRonda",
            ////    principalColumn: "Id",
            ////    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.TemporadaCompeticionJornadaIda_dbo.TemporadaRonda_RondaId",
                table: "TemporadaCompeticionJornada");

            migrationBuilder.DropIndex(
                name: "IX_TemporadaCompeticionJornada_RondaId",
                table: "TemporadaCompeticionJornada");

            migrationBuilder.DropColumn(
                name: "RondaId",
                table: "TemporadaCompeticionJornada");
        }
    }
}
