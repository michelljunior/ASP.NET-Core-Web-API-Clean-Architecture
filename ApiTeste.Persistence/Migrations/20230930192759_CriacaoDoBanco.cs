using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTeste.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblLivros",
                columns: table => new
                {
                    Titulo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Autor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UsuarioId_Insert = table.Column<int>(type: "int", nullable: false),
                    UsuarioId_Update = table.Column<int>(type: "int", nullable: true),
                    UsuarioId_Delete = table.Column<int>(type: "int", nullable: true),
                    DTH_Insert = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DTH_Update = table.Column<DateTime>(type: "datetime", nullable: true),
                    DTH_Delete = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblLivros", x => new { x.Autor, x.Titulo });
                });

            migrationBuilder.CreateTable(
                name: "TblPessoaFisica",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    UsuarioId_Insert = table.Column<int>(type: "int", nullable: false),
                    UsuarioId_Update = table.Column<int>(type: "int", nullable: true),
                    UsuarioId_Delete = table.Column<int>(type: "int", nullable: true),
                    DTH_Insert = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DTH_Update = table.Column<DateTime>(type: "datetime", nullable: true),
                    DTH_Delete = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPessoaFisica", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "TblUsuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Senha = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UsuarioId_Insert = table.Column<int>(type: "int", nullable: false),
                    UsuarioId_Update = table.Column<int>(type: "int", nullable: true),
                    UsuarioId_Delete = table.Column<int>(type: "int", nullable: true),
                    DTH_Insert = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DTH_Update = table.Column<DateTime>(type: "datetime", nullable: true),
                    DTH_Delete = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_TblUsuarios_TblPessoaFisica",
                        column: x => x.CPF,
                        principalTable: "TblPessoaFisica",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblUsuarios_CPF",
                table: "TblUsuarios",
                column: "CPF");

            // Dados do https://www.4devs.com.br/gerador_de_pessoas
            // Senha teste em SHA256

            migrationBuilder.InsertData(
                table: "TblPessoaFisica",
                columns: new[] { "CPF", "Nome", "Celular", "Email", "UsuarioId_Insert", "DTH_Insert" },
                values: new object[] { "61647379237", "Breno Gael Bernardes", "11999999999", "usuario@teste.com", 1, DateTime.Now });

            migrationBuilder.InsertData(
                table: "TblUsuarios",
                columns: new[] { "CPF", "Senha", "UsuarioId_Insert", "DTH_Insert" },
                values: new object[] { "61647379237", "46070d4bf934fb0d4b06d9e2c46e346944e322444900a435d7d9a95e6d7435f5", 1, DateTime.Now });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblLivros");

            migrationBuilder.DropTable(
                name: "TblUsuarios");

            migrationBuilder.DropTable(
                name: "TblPessoaFisica");
        }
    }
}
