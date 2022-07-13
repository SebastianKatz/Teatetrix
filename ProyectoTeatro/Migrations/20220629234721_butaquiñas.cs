using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class butaquiñas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaLibre",
                table: "Butacas");

            migrationBuilder.AddColumn<bool>(
                name: "EstaOcupada",
                table: "Butacas",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaOcupada",
                table: "Butacas");

            migrationBuilder.AddColumn<bool>(
                name: "EstaLibre",
                table: "Butacas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
