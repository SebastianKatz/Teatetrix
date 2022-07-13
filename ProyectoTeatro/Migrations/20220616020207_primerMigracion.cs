using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTeatro.Migrations
{
    public partial class primerMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ButacaReserva",
                columns: table => new
                {
                    IdButacaReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReserva = table.Column<int>(nullable: false),
                    IdButaca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButacaReserva", x => x.IdButacaReserva);
                });

            migrationBuilder.CreateTable(
                name: "Butacas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroButaca = table.Column<int>(nullable: false),
                    EstaLibre = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Butacas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdObra = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaObra = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teatro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaPrincipalid = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Entradas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<double>(nullable: false),
                    NroButaca = table.Column<int>(nullable: false),
                    Teatroid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entradas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entradas_Teatro_Teatroid",
                        column: x => x.Teatroid,
                        principalTable: "Teatro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    IdObra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Teatroid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.IdObra);
                    table.ForeignKey(
                        name: "FK_Obras_Teatro_Teatroid",
                        column: x => x.Teatroid,
                        principalTable: "Teatro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Salaid = table.Column<int>(nullable: true),
                    Teatroid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Salas_Salaid",
                        column: x => x.Salaid,
                        principalTable: "Salas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Teatro_Teatroid",
                        column: x => x.Teatroid,
                        principalTable: "Teatro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entradas_Teatroid",
                table: "Entradas",
                column: "Teatroid");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_Teatroid",
                table: "Obras",
                column: "Teatroid");

            migrationBuilder.CreateIndex(
                name: "IX_Teatro_SalaPrincipalid",
                table: "Teatro",
                column: "SalaPrincipalid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Salaid",
                table: "Usuarios",
                column: "Salaid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Teatroid",
                table: "Usuarios",
                column: "Teatroid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ButacaReserva");

            migrationBuilder.DropTable(
                name: "Butacas");

            migrationBuilder.DropTable(
                name: "Entradas");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Teatro");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
