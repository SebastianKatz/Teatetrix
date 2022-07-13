using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class butacassss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salaid",
                table: "Butacas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Butacas_Salaid",
                table: "Butacas",
                column: "Salaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Butacas_Salas_Salaid",
                table: "Butacas",
                column: "Salaid",
                principalTable: "Salas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Butacas_Salas_Salaid",
                table: "Butacas");

            migrationBuilder.DropIndex(
                name: "IX_Butacas_Salaid",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "Salaid",
                table: "Butacas");
        }
    }
}
