using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class cambioEstructural : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Obras_ObraIdObra",
                table: "Reservas");

            migrationBuilder.DropTable(
                name: "ButacaReserva");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ObraIdObra",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ObraIdObra",
                table: "Reservas");

            migrationBuilder.AddColumn<int>(
                name: "Idbutaca",
                table: "Reservas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdObra",
                table: "Butacas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idbutaca",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdObra",
                table: "Butacas");

            migrationBuilder.AddColumn<int>(
                name: "ObraIdObra",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ButacaReserva",
                columns: table => new
                {
                    IdButacaReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObra = table.Column<int>(type: "int", nullable: false),
                    IdReserva = table.Column<int>(type: "int", nullable: false),
                    NroButaca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButacaReserva", x => x.IdButacaReserva);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ObraIdObra",
                table: "Reservas",
                column: "ObraIdObra");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Obras_ObraIdObra",
                table: "Reservas",
                column: "ObraIdObra",
                principalTable: "Obras",
                principalColumn: "IdObra",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
