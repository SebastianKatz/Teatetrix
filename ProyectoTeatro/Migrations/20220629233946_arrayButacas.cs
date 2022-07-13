using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class arrayButacas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Butacas");

            migrationBuilder.AddColumn<int>(
                name: "ObraIdObra",
                table: "Reservas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdButaca",
                table: "Butacas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas",
                column: "IdButaca");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Obras_ObraIdObra",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_ObraIdObra",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas");

            migrationBuilder.DropColumn(
                name: "ObraIdObra",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdButaca",
                table: "Butacas");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Butacas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Butacas",
                table: "Butacas",
                column: "id");
        }
    }
}
