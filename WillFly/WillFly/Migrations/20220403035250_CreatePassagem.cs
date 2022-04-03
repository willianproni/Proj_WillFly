using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class CreatePassagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Passagem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_CompraId",
                table: "Passagem",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_CompraId",
                table: "Passagem",
                column: "CompraId",
                principalTable: "PrecoBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_CompraId",
                table: "Passagem");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_CompraId",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Passagem");
        }
    }
}
