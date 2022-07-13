using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class sacoTeatro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Teatro_Teatroid",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Obras_Teatro_Teatroid",
                table: "Obras");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Teatro_Teatroid",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Teatro");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Teatroid",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Obras_Teatroid",
                table: "Obras");

            migrationBuilder.DropIndex(
                name: "IX_Entradas_Teatroid",
                table: "Entradas");

            migrationBuilder.DropColumn(
                name: "Teatroid",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Teatroid",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "Teatroid",
                table: "Entradas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teatroid",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teatroid",
                table: "Obras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Teatroid",
                table: "Entradas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teatro",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaPrincipalid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teatro", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teatro_Salas_SalaPrincipalid",
                        column: x => x.SalaPrincipalid,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Teatroid",
                table: "Usuarios",
                column: "Teatroid");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_Teatroid",
                table: "Obras",
                column: "Teatroid");

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_Teatroid",
                table: "Entradas",
                column: "Teatroid");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_SalaPrincipalid",
                table: "Teatro",
                column: "SalaPrincipalid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Teatro_Teatroid",
                table: "Entradas",
                column: "Teatroid",
                principalTable: "Teatro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Obras_Teatro_Teatroid",
                table: "Obras",
                column: "Teatroid",
                principalTable: "Teatro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Teatro_Teatroid",
                table: "Usuarios",
                column: "Teatroid",
                principalTable: "Teatro",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
