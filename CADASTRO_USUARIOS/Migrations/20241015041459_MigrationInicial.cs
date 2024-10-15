using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GERENCIAR_USUARIOS.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    USUARIO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NOME = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EMAIL = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SENHA = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NIVEL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CRIADOPOR = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CRIADOEM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ALTERADOPOR = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ALTERADOEM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.USUARIO);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "USUARIOS",
                columns: new[] { "USUARIO", "ALTERADOEM", "ALTERADOPOR", "CRIADOEM", "CRIADOPOR", "EMAIL", "NIVEL", "NOME", "SENHA" },
                values: new object[] { "admin", new DateTime(2024, 10, 15, 1, 14, 59, 251, DateTimeKind.Local).AddTicks(8820), "admin", new DateTime(2024, 10, 15, 1, 14, 59, 251, DateTimeKind.Local).AddTicks(8804), "admin", "email@teste.com.br", "A", "ADMIN", "$2a$11$IlnYxBzBJncE22K4KNGHhebxVCDdsbRlKKb8ufoyYGhbEMW25mY4W" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
