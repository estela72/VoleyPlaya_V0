using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class alineacionLibre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "oldAspNetUserClaimsDTO");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetUserLoginsDTO");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "oldAspNetUsers");

            //migrationBuilder.AddColumn<bool>(
            //    name: "AlineacionLibre",
            //    table: "TemporadaCompeticionJornada",
            //    nullable: false,
            //    defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlineacionLibre",
                table: "TemporadaCompeticionJornada");

            //    migrationBuilder.CreateTable(
            //        name: "oldAspNetRoles",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(maxLength: 128, nullable: false),
            //            Name = table.Column<string>(maxLength: 256, nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_oldAspNetRoles", x => x.Id);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "oldAspNetUsers",
            //        columns: table => new
            //        {
            //            Id = table.Column<string>(maxLength: 128, nullable: false),
            //            AccessFailedCount = table.Column<int>(nullable: false),
            //            City = table.Column<string>(nullable: true),
            //            CompartirGrupo = table.Column<string>(nullable: true),
            //            Conocimiento = table.Column<string>(nullable: true),
            //            Email = table.Column<string>(maxLength: 256, nullable: true),
            //            EmailConfirmed = table.Column<bool>(nullable: false),
            //            Equipo = table.Column<string>(nullable: true),
            //            LastLogin = table.Column<DateTime>(type: "datetime", nullable: false),
            //            LastLogout = table.Column<DateTime>(type: "datetime", nullable: false),
            //            LockoutEnabled = table.Column<bool>(nullable: false),
            //            LockoutEndDateUtc = table.Column<DateTime>(type: "datetime", nullable: true),
            //            LoginCount = table.Column<int>(nullable: false),
            //            PasswordHash = table.Column<string>(nullable: true),
            //            PhoneNumber = table.Column<string>(nullable: true),
            //            PhoneNumberConfirmed = table.Column<bool>(nullable: false),
            //            SecurityStamp = table.Column<string>(nullable: true),
            //            TwoFactorEnabled = table.Column<bool>(nullable: false),
            //            UserName = table.Column<string>(maxLength: 256, nullable: false),
            //            UserState = table.Column<int>(nullable: false),
            //            Whatsap = table.Column<bool>(nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_oldAspNetUsers", x => x.Id);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "oldAspNetUserClaimsDTO",
            //        columns: table => new
            //        {
            //            Id = table.Column<int>(nullable: false)
            //                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //            ClaimType = table.Column<string>(nullable: true),
            //            ClaimValue = table.Column<string>(nullable: true),
            //            UserId = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_oldAspNetUserClaimsDTO", x => x.Id);
            //            table.ForeignKey(
            //                name: "FK_oldAspNetUserClaimsDTO_oldAspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "oldAspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Restrict);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "oldAspNetUserLoginsDTO",
            //        columns: table => new
            //        {
            //            UserId = table.Column<string>(nullable: false),
            //            LoginProvider = table.Column<string>(nullable: true),
            //            ProviderKey = table.Column<string>(nullable: true),
            //            UserId1 = table.Column<string>(nullable: true)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_oldAspNetUserLoginsDTO", x => x.UserId);
            //            table.ForeignKey(
            //                name: "FK_oldAspNetUserLoginsDTO_oldAspNetUsers_UserId1",
            //                column: x => x.UserId1,
            //                principalTable: "oldAspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Restrict);
            //        });

            //    migrationBuilder.CreateTable(
            //        name: "oldAspNetUserRoles",
            //        columns: table => new
            //        {
            //            UserId = table.Column<string>(maxLength: 128, nullable: false),
            //            RoleId = table.Column<string>(maxLength: 128, nullable: false)
            //        },
            //        constraints: table =>
            //        {
            //            table.PrimaryKey("PK_oldAspNetUserRoles", x => new { x.UserId, x.RoleId });
            //            table.ForeignKey(
            //                name: "OLDFK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId",
            //                column: x => x.RoleId,
            //                principalTable: "oldAspNetRoles",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Restrict);
            //            table.ForeignKey(
            //                name: "OLDFK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId",
            //                column: x => x.UserId,
            //                principalTable: "oldAspNetUsers",
            //                principalColumn: "Id",
            //                onDelete: ReferentialAction.Restrict);
            //        });

            //    migrationBuilder.CreateIndex(
            //        name: "OLDRoleNameIndex",
            //        table: "oldAspNetRoles",
            //        column: "Name",
            //        unique: true);

            //    migrationBuilder.CreateIndex(
            //        name: "IX_oldAspNetUserClaimsDTO_UserId",
            //        table: "oldAspNetUserClaimsDTO",
            //        column: "UserId");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_oldAspNetUserLoginsDTO_UserId1",
            //        table: "oldAspNetUserLoginsDTO",
            //        column: "UserId1");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_oldAspNetUserRoles_RoleId",
            //        table: "oldAspNetUserRoles",
            //        column: "RoleId");

            //    migrationBuilder.CreateIndex(
            //        name: "OLDUserNameIndex",
            //        table: "oldAspNetUsers",
            //        column: "UserName",
            //        unique: true);
        }
    }
}
