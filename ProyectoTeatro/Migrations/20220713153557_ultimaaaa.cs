using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class ultimaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ButacasMax",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "CapacidadMax",
                table: "Salas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacidadMax",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "ButacasMax",
                table: "Salas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
