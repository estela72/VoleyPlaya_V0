using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class temporadacompeticionjornada_ronda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaVueltaID",
            //    table: "TemporadaRonda");

            //migrationBuilder.AlterColumn<int>(
            //    name: "JornadaVueltaID",
            //    table: "TemporadaRonda",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaVueltaID",
            //    table: "TemporadaRonda",
            //    column: "JornadaVueltaID",
            //    principalTable: "TemporadaCompeticionJornada",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaVueltaID",
                table: "TemporadaRonda");

            migrationBuilder.AlterColumn<int>(
                name: "JornadaVueltaID",
                table: "TemporadaRonda",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaVueltaID",
                table: "TemporadaRonda",
                column: "JornadaVueltaID",
                principalTable: "TemporadaCompeticionJornada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
