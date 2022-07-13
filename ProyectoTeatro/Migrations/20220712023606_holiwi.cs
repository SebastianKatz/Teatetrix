using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class holiwi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdButaca",
                table: "ButacaReserva");

            migrationBuilder.AddColumn<int>(
                name: "IdObra",
                table: "ButacaReserva",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NroButaca",
                table: "ButacaReserva",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdObra",
                table: "ButacaReserva");

            migrationBuilder.DropColumn(
                name: "NroButaca",
                table: "ButacaReserva");

            migrationBuilder.AddColumn<int>(
                name: "IdButaca",
                table: "ButacaReserva",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
