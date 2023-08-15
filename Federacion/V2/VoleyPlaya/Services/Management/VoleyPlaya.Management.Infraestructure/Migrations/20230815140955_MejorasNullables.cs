using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoleyPlaya.Management.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class MejorasNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Partidos_Label",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "EdicionGrupos");

            migrationBuilder.DropColumn(
                name: "TipoCalendario",
                table: "Ediciones");

            migrationBuilder.RenameColumn(
                name: "Jornada",
                table: "Partidos",
                newName: "JornadaId");

            migrationBuilder.AlterColumn<int>(
                name: "NumPartido",
                table: "Partidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Partidos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fase",
                table: "EdicionGrupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ModeloCompeticion",
                table: "Ediciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Genero",
                table: "Ediciones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_JornadaId",
                table: "Partidos",
                column: "JornadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Label",
                table: "Partidos",
                column: "Label",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Jornada_JornadaId",
                table: "Partidos",
                column: "JornadaId",
                principalTable: "Jornada",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Jornada_JornadaId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_JornadaId",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_Label",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Fase",
                table: "EdicionGrupos");

            migrationBuilder.RenameColumn(
                name: "JornadaId",
                table: "Partidos",
                newName: "Jornada");

            migrationBuilder.AlterColumn<int>(
                name: "NumPartido",
                table: "Partidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "Partidos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "EdicionGrupos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ModeloCompeticion",
                table: "Ediciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Genero",
                table: "Ediciones",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TipoCalendario",
                table: "Ediciones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Label",
                table: "Partidos",
                column: "Label",
                unique: true,
                filter: "[Label] IS NOT NULL");
        }
    }
}
