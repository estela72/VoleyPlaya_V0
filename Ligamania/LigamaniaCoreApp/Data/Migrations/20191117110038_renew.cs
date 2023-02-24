using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class renew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_TemporadaCompeticionCategoriaReferencia_Temporada_Temporada_DTOId",
            //    table: "TemporadaCompeticionCategoriaReferencia");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetUserClaims_DTO");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetUserLogins_DTO");

            //migrationBuilder.RenameColumn(
            //    name: "Temporada_DTOId",
            //    table: "TemporadaCompeticionCategoriaReferencia",
            //    newName: "TemporadaDTOId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_TemporadaCompeticionCategoriaReferencia_Temporada_DTOId",
            //    table: "TemporadaCompeticionCategoriaReferencia",
            //    newName: "IX_TemporadaCompeticionCategoriaReferencia_TemporadaDTOId");

            //migrationBuilder.CreateTable(
            //    name: "oldAspNetUserClaimsDTO",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserId = table.Column<string>(nullable: true),
            //        ClaimType = table.Column<string>(nullable: true),
            //        ClaimValue = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_oldAspNetUserClaimsDTO", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_oldAspNetUserClaimsDTO_oldAspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "oldAspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "oldAspNetUserLoginsDTO",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(nullable: false),
            //        LoginProvider = table.Column<string>(nullable: true),
            //        ProviderKey = table.Column<string>(nullable: true),
            //        UserId1 = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_oldAspNetUserLoginsDTO", x => x.UserId);
            //        table.ForeignKey(
            //            name: "FK_oldAspNetUserLoginsDTO_oldAspNetUsers_UserId1",
            //            column: x => x.UserId1,
            //            principalTable: "oldAspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_oldAspNetUserClaimsDTO_UserId",
            //    table: "oldAspNetUserClaimsDTO",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_oldAspNetUserLoginsDTO_UserId1",
            //    table: "oldAspNetUserLoginsDTO",
            //    column: "UserId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_TemporadaCompeticionCategoriaReferencia_Temporada_TemporadaDTOId",
            //    table: "TemporadaCompeticionCategoriaReferencia",
            //    column: "TemporadaDTOId",
            //    principalTable: "Temporada",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemporadaCompeticionCategoriaReferencia_Temporada_TemporadaDTOId",
                table: "TemporadaCompeticionCategoriaReferencia");

            migrationBuilder.DropTable(
                name: "oldAspNetUserClaimsDTO");

            migrationBuilder.DropTable(
                name: "oldAspNetUserLoginsDTO");

            migrationBuilder.RenameColumn(
                name: "TemporadaDTOId",
                table: "TemporadaCompeticionCategoriaReferencia",
                newName: "Temporada_DTOId");

            migrationBuilder.RenameIndex(
                name: "IX_TemporadaCompeticionCategoriaReferencia_TemporadaDTOId",
                table: "TemporadaCompeticionCategoriaReferencia",
                newName: "IX_TemporadaCompeticionCategoriaReferencia_Temporada_DTOId");

            migrationBuilder.CreateTable(
                name: "oldAspNetUserClaims_DTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oldAspNetUserClaims_DTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_oldAspNetUserClaims_DTO_oldAspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "oldAspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "oldAspNetUserLogins_DTO",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    UserId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oldAspNetUserLogins_DTO", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_oldAspNetUserLogins_DTO_oldAspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "oldAspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_oldAspNetUserClaims_DTO_UserId",
                table: "oldAspNetUserClaims_DTO",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_oldAspNetUserLogins_DTO_UserId1",
                table: "oldAspNetUserLogins_DTO",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporadaCompeticionCategoriaReferencia_Temporada_Temporada_DTOId",
                table: "TemporadaCompeticionCategoriaReferencia",
                column: "Temporada_DTOId",
                principalTable: "Temporada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
