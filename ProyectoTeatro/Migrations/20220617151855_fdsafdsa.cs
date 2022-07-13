using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class fdsafdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Reservas");
        }
    }
}
