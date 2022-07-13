using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class vfdsavf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Salas_Salaid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Salaid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Salaid",
                table: "Usuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salaid",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Salaid",
                table: "Usuarios",
                column: "Salaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Salas_Salaid",
                table: "Usuarios",
                column: "Salaid",
                principalTable: "Salas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
