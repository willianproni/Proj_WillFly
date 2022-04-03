using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class CreatePrecoBas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Passageiro_PassageiroCpf",
                table: "Voo");

            migrationBuilder.DropIndex(
                name: "IX_Voo_PassageiroCpf",
                table: "Voo");

            migrationBuilder.DropColumn(
                name: "PassageiroCpf",
                table: "Voo");

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassageiroCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagem_Passageiro_PassageiroCpf",
                        column: x => x.PassageiroCpf,
                        principalTable: "Passageiro",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PassageiroCpf",
                table: "Passagem",
                column: "PassageiroCpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.AddColumn<string>(
                name: "PassageiroCpf",
                table: "Voo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voo_PassageiroCpf",
                table: "Voo",
                column: "PassageiroCpf");

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Passageiro_PassageiroCpf",
                table: "Voo",
                column: "PassageiroCpf",
                principalTable: "Passageiro",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
