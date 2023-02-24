using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class temporadaronda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "TemporadaRonda",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
            //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
            //        NumRonda = table.Column<int>(nullable: false),
            //        RondaFinal = table.Column<bool>(nullable: false),
            //        TemporadaID = table.Column<int>(nullable: false),
            //        CompeticionID = table.Column<int>(nullable: false),
            //        JornadaIdaID = table.Column<int>(nullable: false),
            //        JornadaVueltaID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TemporadaRonda", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_dbo.TemporadaRonda_dbo.Competicion_CompeticionID",
            //            column: x => x.CompeticionID,
            //            principalTable: "Competicion",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaIdaID",
            //            column: x => x.JornadaIdaID,
            //            principalTable: "TemporadaCompeticionJornada",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_TemporadaRonda_TemporadaCompeticionJornada_JornadaVueltaID",
            //            column: x => x.JornadaVueltaID,
            //            principalTable: "TemporadaCompeticionJornada",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_dbo.TemporadaRonda_dbo.Temporada_TemporadaID",
            //            column: x => x.TemporadaID,
            //            principalTable: "Temporada",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemporadaRonda_CompeticionID",
            //    table: "TemporadaRonda",
            //    column: "CompeticionID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemporadaRonda_JornadaIdaID",
            //    table: "TemporadaRonda",
            //    column: "JornadaIdaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemporadaRonda_JornadaVueltaID",
            //    table: "TemporadaRonda",
            //    column: "JornadaVueltaID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TemporadaRonda",
            //    table: "TemporadaRonda",
            //    columns: new[] { "TemporadaID", "CompeticionID", "NumRonda" },
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemporadaRonda");
        }
    }
}
