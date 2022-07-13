using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class salasagregadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Butacas_Obras_ObraIdObra",
                table: "Butacas");

            migrationBuilder.DropIndex(
                name: "IX_Butacas_ObraIdObra",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "ObraIdObra",
                table: "Butacas");

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Obras",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Obras");

            migrationBuilder.AddColumn<int>(
                name: "ObraIdObra",
                table: "Butacas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_ObraIdObra",
                table: "Butacas",
                column: "ObraIdObra");

            migrationBuilder.AddForeignKey(
                name: "FK_Butacas_Obras_ObraIdObra",
                table: "Butacas",
                column: "ObraIdObra",
                principalTable: "Obras",
                principalColumn: "IdObra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
