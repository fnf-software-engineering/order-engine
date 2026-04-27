using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderEngine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaTerceirosFornecedorCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cad_terceiros",
                columns: table => new
                {
                    id_terceiro = table.Column<Guid>(type: "uuid", nullable: false),
                    id_empresa = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo_pessoa = table.Column<int>(type: "char(1)", nullable: false),
                    documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    razao_nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    nome_fantasia = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    inscricao_estadual = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    inscricao_municipal = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    rg = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    telefone = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    celular = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    cep = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    endereco = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    numero = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    complemento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    bairro = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    cidade = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    uf = table.Column<string>(type: "char(2)", nullable: true),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_terceiros", x => x.id_terceiro);
                    table.ForeignKey(
                        name: "FK_cad_terceiros_erp_empresas_id_empresa",
                        column: x => x.id_empresa,
                        principalTable: "erp_empresas",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cad_clientes",
                columns: table => new
                {
                    id_cliente = table.Column<Guid>(type: "uuid", nullable: false),
                    id_terceiro = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    limite_credito = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    limite_debito = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m),
                    consumidor_final = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    contribuinte_icms = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    bloqueado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    motivo_bloqueio = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_clientes", x => x.id_cliente);
                    table.ForeignKey(
                        name: "FK_cad_clientes_cad_terceiros_id_terceiro",
                        column: x => x.id_terceiro,
                        principalTable: "cad_terceiros",
                        principalColumn: "id_terceiro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cad_fornedores",
                columns: table => new
                {
                    id_fornecedor = table.Column<Guid>(type: "uuid", nullable: false),
                    id_terceiro = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    tipo_fornecedor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    bloqueado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    motivo_bloqueio = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    data_alteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_fornedores", x => x.id_fornecedor);
                    table.ForeignKey(
                        name: "FK_cad_fornedores_cad_terceiros_id_terceiro",
                        column: x => x.id_terceiro,
                        principalTable: "cad_terceiros",
                        principalColumn: "id_terceiro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cad_terceiro_filiais",
                columns: table => new
                {
                    id_terceiro = table.Column<Guid>(type: "uuid", nullable: false),
                    id_filial = table.Column<Guid>(type: "uuid", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    data_cadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_terceiro_filiais", x => new { x.id_terceiro, x.id_filial });
                    table.ForeignKey(
                        name: "FK_cad_terceiro_filiais_cad_terceiros_id_terceiro",
                        column: x => x.id_terceiro,
                        principalTable: "cad_terceiros",
                        principalColumn: "id_terceiro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cad_terceiro_filiais_erp_filiais_id_filial",
                        column: x => x.id_filial,
                        principalTable: "erp_filiais",
                        principalColumn: "id_filial",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_codigo_cliente",
                table: "cad_clientes",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "ux_terceiros_clientes",
                table: "cad_clientes",
                column: "id_terceiro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_codigo_fornecedor",
                table: "cad_fornedores",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "ux_fornecedor_id_terceiro",
                table: "cad_fornedores",
                column: "id_terceiro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cad_terceiro_filiais_id_filial",
                table: "cad_terceiro_filiais",
                column: "id_filial");

            migrationBuilder.CreateIndex(
                name: "ix_terceiros_empresa_documento",
                table: "cad_terceiros",
                columns: new[] { "id_empresa", "documento" });

            migrationBuilder.CreateIndex(
                name: "ix_terceiros_empresa_razao_nome",
                table: "cad_terceiros",
                columns: new[] { "id_empresa", "razao_nome" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cad_clientes");

            migrationBuilder.DropTable(
                name: "cad_fornedores");

            migrationBuilder.DropTable(
                name: "cad_terceiro_filiais");

            migrationBuilder.DropTable(
                name: "cad_terceiros");
        }
    }
}
