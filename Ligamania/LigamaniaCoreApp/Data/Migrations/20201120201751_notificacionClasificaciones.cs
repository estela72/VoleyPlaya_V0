using Microsoft.EntityFrameworkCore.Migrations;

namespace LigamaniaCoreApp.Data.Migrations
{
    public partial class notificacionClasificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NotificacionClasificaciones",
                table: "Settings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificacionClasificaciones",
                table: "Settings");
        }
    }
}
