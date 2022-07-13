using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class mejoraa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Butacas_Salas_Salaid",
                table: "Butacas");

            migrationBuilder.DropTable(
                name: "Salas");

            migrationBuilder.DropIndex(
                name: "IX_Butacas_Salaid",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Salaid",
                table: "Butacas");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ObraIdObra",
                table: "Butacas",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Butacas_Obras_ObraIdObra",
                table: "Butacas");

            migrationBuilder.DropIndex(
                name: "IX_Butacas_ObraIdObra",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ObraIdObra",
                table: "Butacas");

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Salaid",
                table: "Butacas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.id);
                });

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
    }
}
