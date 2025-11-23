using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FotoPerfilUrl = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Discussao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoPaiId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discussao_Discussao_DiscussaoPaiId",
                        column: x => x.DiscussaoPaiId,
                        principalTable: "Discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discussao_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Discussao_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visualizada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioDestinoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagem_Usuario_UsuarioDestinoId",
                        column: x => x.UsuarioDestinoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PastaEstudo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PastaEstudoPaiId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visibilidade = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaEstudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastaEstudo_PastaEstudo_PastaEstudoPaiId",
                        column: x => x.PastaEstudoPaiId,
                        principalTable: "PastaEstudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PastaEstudo_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PastaEstudo_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DiscussaoReacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussaoReacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscussaoReacao_Discussao_DiscussaoId",
                        column: x => x.DiscussaoId,
                        principalTable: "Discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussaoReacao_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscussaoReacao_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscussaoReacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoId = table.Column<int>(type: "int", nullable: false),
                    RespostaPaiId = table.Column<int>(type: "int", nullable: true),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resposta_Discussao_DiscussaoId",
                        column: x => x.DiscussaoId,
                        principalTable: "Discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_Resposta_RespostaPaiId",
                        column: x => x.RespostaPaiId,
                        principalTable: "Resposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resposta_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resposta_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tipo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TamanhoBytes = table.Column<long>(type: "bigint", nullable: false),
                    PastaEstudoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arquivo_PastaEstudo_PastaEstudoId",
                        column: x => x.PastaEstudoId,
                        principalTable: "PastaEstudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arquivo_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Arquivo_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RespostaReacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RespostaId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaReacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostaReacao_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalTable: "Resposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaReacao_Usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RespostaReacao_Usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaReacao_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_PastaEstudoId",
                table: "Arquivo",
                column: "PastaEstudoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_UsuarioAlteracaoId",
                table: "Arquivo",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivo_UsuarioCriacaoId",
                table: "Arquivo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussao_DiscussaoPaiId",
                table: "Discussao",
                column: "DiscussaoPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussao_UsuarioAlteracaoId",
                table: "Discussao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Discussao_UsuarioCriacaoId",
                table: "Discussao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussaoReacao_DiscussaoId",
                table: "DiscussaoReacao",
                column: "DiscussaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussaoReacao_UsuarioAlteracaoId",
                table: "DiscussaoReacao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussaoReacao_UsuarioCriacaoId",
                table: "DiscussaoReacao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussaoReacao_UsuarioId",
                table: "DiscussaoReacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuarioAlteracaoId",
                table: "Mensagem",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuarioCriacaoId",
                table: "Mensagem",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_UsuarioDestinoId",
                table: "Mensagem",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_PastaEstudo_PastaEstudoPaiId",
                table: "PastaEstudo",
                column: "PastaEstudoPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_PastaEstudo_UsuarioAlteracaoId",
                table: "PastaEstudo",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PastaEstudo_UsuarioCriacaoId",
                table: "PastaEstudo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_DiscussaoId",
                table: "Resposta",
                column: "DiscussaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_RespostaPaiId",
                table: "Resposta",
                column: "RespostaPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_UsuarioAlteracaoId",
                table: "Resposta",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_UsuarioCriacaoId",
                table: "Resposta",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaReacao_RespostaId",
                table: "RespostaReacao",
                column: "RespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaReacao_UsuarioAlteracaoId",
                table: "RespostaReacao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaReacao_UsuarioCriacaoId",
                table: "RespostaReacao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaReacao_UsuarioId",
                table: "RespostaReacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "DiscussaoReacao");

            migrationBuilder.DropTable(
                name: "Mensagem");

            migrationBuilder.DropTable(
                name: "RespostaReacao");

            migrationBuilder.DropTable(
                name: "PastaEstudo");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Discussao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
