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
                name: "usuario",
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
                    table.PrimaryKey("PK_usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "discussao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoPaiId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discussao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_discussao_discussao_DiscussaoPaiId",
                        column: x => x.DiscussaoPaiId,
                        principalTable: "discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discussao_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discussao_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discussao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mensagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visualizada = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UsuarioDestinoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mensagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mensagem_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mensagem_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mensagem_usuario_UsuarioDestinoId",
                        column: x => x.UsuarioDestinoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mensagem_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pasta_estudo",
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pasta_estudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pasta_estudo_pasta_estudo_PastaEstudoPaiId",
                        column: x => x.PastaEstudoPaiId,
                        principalTable: "pasta_estudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pasta_estudo_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pasta_estudo_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pasta_estudo_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "discussao_reacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discussao_reacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_discussao_reacao_discussao_DiscussaoId",
                        column: x => x.DiscussaoId,
                        principalTable: "discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discussao_reacao_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discussao_reacao_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_discussao_reacao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiscussaoId = table.Column<int>(type: "int", nullable: false),
                    RespostaPaiId = table.Column<int>(type: "int", nullable: true),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resposta_discussao_DiscussaoId",
                        column: x => x.DiscussaoId,
                        principalTable: "discussao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resposta_resposta_RespostaPaiId",
                        column: x => x.RespostaPaiId,
                        principalTable: "resposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resposta_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resposta_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resposta_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "arquivo",
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
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_arquivo_pasta_estudo_PastaEstudoId",
                        column: x => x.PastaEstudoId,
                        principalTable: "pasta_estudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_arquivo_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_arquivo_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_arquivo_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resposta_reacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RespostaId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioAlteracaoId = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resposta_reacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resposta_reacao_resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalTable: "resposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resposta_reacao_usuario_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resposta_reacao_usuario_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_resposta_reacao_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuario",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "DataAlteracao", "DataCriacao", "Email", "FotoPerfilUrl", "Nome", "Senha", "Telefone", "TipoUsuario", "UsuarioAlteracaoId", "UsuarioCriacaoId" },
                values: new object[] { 1, null, new DateTime(2025, 11, 24, 19, 16, 10, 308, DateTimeKind.Local).AddTicks(458), "admin", "", "Admin", "UPHOAqVE0er6hexBH82HaEWie+OWSko2VBy2lzqVUHg=", "0000000", 2, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_arquivo_PastaEstudoId",
                table: "arquivo",
                column: "PastaEstudoId");

            migrationBuilder.CreateIndex(
                name: "IX_arquivo_UsuarioAlteracaoId",
                table: "arquivo",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_arquivo_UsuarioCriacaoId",
                table: "arquivo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_arquivo_UsuarioId",
                table: "arquivo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_DiscussaoPaiId",
                table: "discussao",
                column: "DiscussaoPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_UsuarioAlteracaoId",
                table: "discussao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_UsuarioCriacaoId",
                table: "discussao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_UsuarioId",
                table: "discussao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_reacao_DiscussaoId",
                table: "discussao_reacao",
                column: "DiscussaoId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_reacao_UsuarioAlteracaoId",
                table: "discussao_reacao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_reacao_UsuarioCriacaoId",
                table: "discussao_reacao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_discussao_reacao_UsuarioId",
                table: "discussao_reacao",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_UsuarioAlteracaoId",
                table: "mensagem",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_UsuarioCriacaoId",
                table: "mensagem",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_UsuarioDestinoId",
                table: "mensagem",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_mensagem_UsuarioId",
                table: "mensagem",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_pasta_estudo_PastaEstudoPaiId",
                table: "pasta_estudo",
                column: "PastaEstudoPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_pasta_estudo_UsuarioAlteracaoId",
                table: "pasta_estudo",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_pasta_estudo_UsuarioCriacaoId",
                table: "pasta_estudo",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_pasta_estudo_UsuarioId",
                table: "pasta_estudo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_DiscussaoId",
                table: "resposta",
                column: "DiscussaoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_RespostaPaiId",
                table: "resposta",
                column: "RespostaPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_UsuarioAlteracaoId",
                table: "resposta",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_UsuarioCriacaoId",
                table: "resposta",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_UsuarioId",
                table: "resposta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_reacao_RespostaId",
                table: "resposta_reacao",
                column: "RespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_reacao_UsuarioAlteracaoId",
                table: "resposta_reacao",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_reacao_UsuarioCriacaoId",
                table: "resposta_reacao",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_resposta_reacao_UsuarioId",
                table: "resposta_reacao",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arquivo");

            migrationBuilder.DropTable(
                name: "discussao_reacao");

            migrationBuilder.DropTable(
                name: "mensagem");

            migrationBuilder.DropTable(
                name: "resposta_reacao");

            migrationBuilder.DropTable(
                name: "pasta_estudo");

            migrationBuilder.DropTable(
                name: "resposta");

            migrationBuilder.DropTable(
                name: "discussao");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
