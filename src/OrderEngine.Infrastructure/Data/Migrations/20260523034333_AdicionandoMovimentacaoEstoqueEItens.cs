using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderEngine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoMovimentacaoEstoqueEItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "est_movimentacoes",
                columns: table => new
                {
                    id_movimentacao = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: false),
                    id_tipo_movimentacao = table.Column<Guid>(type: "uuid", nullable: false),
                    numero_documento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    origem = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    data_movimentacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: true),
                    cancelada = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    data_cancelamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    motivo_cancelamento = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_movimentacoes", x => x.id_movimentacao);
                    table.ForeignKey(
                        name: "FK_est_movimentacoes_erp_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "erp_empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_est_movimentacoes_erp_filiais_id_filial",
                        column: x => x.id_filial,
                        principalTable: "erp_filiais",
                        principalColumn: "id_filial",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_est_movimentacoes_est_tipos_movimentacao_id_tipo_movimentac~",
                        column: x => x.id_tipo_movimentacao,
                        principalTable: "est_tipos_movimentacao",
                        principalColumn: "id_tipo_movimentacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "est_movimentacao_itens",
                columns: table => new
                {
                    id_movimentacao_item = table.Column<Guid>(type: "uuid", nullable: false),
                    id_movimentacao = table.Column<Guid>(type: "uuid", nullable: false),
                    id_produto = table.Column<Guid>(type: "uuid", nullable: false),
                    quantidade = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    valor_unitario = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false, defaultValue: 0m),
                    custo_anterior = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    custo_novo = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: true),
                    observacao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_est_movimentacao_itens", x => x.id_movimentacao_item);
                    table.ForeignKey(
                        name: "FK_est_movimentacao_itens_est_movimentacoes_id_movimentacao",
                        column: x => x.id_movimentacao,
                        principalTable: "est_movimentacoes",
                        principalColumn: "id_movimentacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_est_movimentacao_itens_prod_produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "prod_produtos",
                        principalColumn: "id_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_est_movimentacao_itens_id_movimentacao",
                table: "est_movimentacao_itens",
                column: "id_movimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_est_movimentacao_itens_id_produto",
                table: "est_movimentacao_itens",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_est_movimentacoes_id_empresa",
                table: "est_movimentacoes",
                column: "id_empresa");

            migrationBuilder.CreateIndex(
                name: "IX_est_movimentacoes_id_filial",
                table: "est_movimentacoes",
                column: "id_filial");

            migrationBuilder.CreateIndex(
                name: "IX_est_movimentacoes_id_tipo_movimentacao",
                table: "est_movimentacoes",
                column: "id_tipo_movimentacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "est_movimentacao_itens");

            migrationBuilder.DropTable(
                name: "est_movimentacoes");
        }
    }
}
