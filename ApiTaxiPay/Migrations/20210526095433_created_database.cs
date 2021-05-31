using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APITaxiPay.Migrations
{
    public partial class created_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinos",
                columns: table => new
                {
                    DestinoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinos", x => x.DestinoID);
                });

            migrationBuilder.CreateTable(
                name: "Origens",
                columns: table => new
                {
                    OrigemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origens", x => x.OrigemID);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaID);
                });

            migrationBuilder.CreateTable(
                name: "Rotas",
                columns: table => new
                {
                    RotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custo = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinoID = table.Column<int>(type: "int", nullable: false),
                    OrigemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotas", x => x.RotaID);
                    table.ForeignKey(
                        name: "FK_Rotas_Destinos_DestinoID",
                        column: x => x.DestinoID,
                        principalTable: "Destinos",
                        principalColumn: "DestinoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rotas_Origens_OrigemID",
                        column: x => x.OrigemID,
                        principalTable: "Origens",
                        principalColumn: "OrigemID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    NumeroAssociado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.PessoaID);
                    table.ForeignKey(
                        name: "FK_Cobradores_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    NumeroCarta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.PessoaID);
                    table.ForeignKey(
                        name: "FK_Motoristas_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    PessoaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.PessoaID);
                    table.ForeignKey(
                        name: "FK_Passageiros_Pessoas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    CarroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.CarroID);
                    table.ForeignKey(
                        name: "FK_Carros_Motoristas_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Motoristas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Carteiras",
                columns: table => new
                {
                    CarteiraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carteiras", x => x.CarteiraID);
                    table.ForeignKey(
                        name: "FK_Carteiras_Passageiros_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "Passageiros",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diarias",
                columns: table => new
                {
                    DiariaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarroID = table.Column<int>(type: "int", nullable: false),
                    PessoaID = table.Column<int>(type: "int", nullable: false),
                    MotoristaPessoaID = table.Column<int>(type: "int", nullable: true),
                    CobradorPessoaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarias", x => x.DiariaID);
                    table.ForeignKey(
                        name: "FK_Diarias_Carros_CarroID",
                        column: x => x.CarroID,
                        principalTable: "Carros",
                        principalColumn: "CarroID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarias_Cobradores_CobradorPessoaID",
                        column: x => x.CobradorPessoaID,
                        principalTable: "Cobradores",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Diarias_Motoristas_MotoristaPessoaID",
                        column: x => x.MotoristaPessoaID,
                        principalTable: "Motoristas",
                        principalColumn: "PessoaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Corridas",
                columns: table => new
                {
                    CorridaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RotaID = table.Column<int>(type: "int", nullable: false),
                    DiariaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corridas", x => x.CorridaID);
                    table.ForeignKey(
                        name: "FK_Corridas_Diarias_DiariaID",
                        column: x => x.DiariaID,
                        principalTable: "Diarias",
                        principalColumn: "DiariaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Corridas_Rotas_RotaID",
                        column: x => x.RotaID,
                        principalTable: "Rotas",
                        principalColumn: "RotaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    PagamentoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorridaID = table.Column<int>(type: "int", nullable: false),
                    CarteiraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.PagamentoID);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Carteiras_CarteiraID",
                        column: x => x.CarteiraID,
                        principalTable: "Carteiras",
                        principalColumn: "CarteiraID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Corridas_CorridaID",
                        column: x => x.CorridaID,
                        principalTable: "Corridas",
                        principalColumn: "CorridaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carros_PessoaID",
                table: "Carros",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Carteiras_PessoaID",
                table: "Carteiras",
                column: "PessoaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_DiariaID",
                table: "Corridas",
                column: "DiariaID");

            migrationBuilder.CreateIndex(
                name: "IX_Corridas_RotaID",
                table: "Corridas",
                column: "RotaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_CarroID",
                table: "Diarias",
                column: "CarroID");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_CobradorPessoaID",
                table: "Diarias",
                column: "CobradorPessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Diarias_MotoristaPessoaID",
                table: "Diarias",
                column: "MotoristaPessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CarteiraID",
                table: "Pagamentos",
                column: "CarteiraID");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_CorridaID",
                table: "Pagamentos",
                column: "CorridaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_DestinoID",
                table: "Rotas",
                column: "DestinoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rotas_OrigemID",
                table: "Rotas",
                column: "OrigemID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Carteiras");

            migrationBuilder.DropTable(
                name: "Corridas");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Diarias");

            migrationBuilder.DropTable(
                name: "Rotas");

            migrationBuilder.DropTable(
                name: "Carros");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Destinos");

            migrationBuilder.DropTable(
                name: "Origens");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
