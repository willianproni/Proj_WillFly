using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class InitialPrecoBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecoBase",
                columns: table => new
                {
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrigemSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DestinoSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PromocaoPocentagem = table.Column<double>(type: "float", nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoBase", x => x.DataInclusao);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Aeroporto_DestinoSigla",
                        column: x => x.DestinoSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Aeroporto_OrigemSigla",
                        column: x => x.OrigemSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrecoBase_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_ClasseId",
                table: "PrecoBase",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_DestinoSigla",
                table: "PrecoBase",
                column: "DestinoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_OrigemSigla",
                table: "PrecoBase",
                column: "OrigemSigla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecoBase");
        }
    }
}
