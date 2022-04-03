using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class CreatePrecoBase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrecoBase_Aeroporto_DestinoSigla",
                table: "PrecoBase");

            migrationBuilder.DropForeignKey(
                name: "FK_PrecoBase_Aeroporto_OrigemSigla",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_PrecoBase_DestinoSigla",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_PrecoBase_OrigemSigla",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "DestinoSigla",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "OrigemSigla",
                table: "PrecoBase");

            migrationBuilder.AddColumn<int>(
                name: "VooId",
                table: "PrecoBase",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_VooId",
                table: "PrecoBase",
                column: "VooId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoBase_Voo_VooId",
                table: "PrecoBase",
                column: "VooId",
                principalTable: "Voo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrecoBase_Voo_VooId",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_PrecoBase_VooId",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "VooId",
                table: "PrecoBase");

            migrationBuilder.AddColumn<string>(
                name: "DestinoSigla",
                table: "PrecoBase",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrigemSigla",
                table: "PrecoBase",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_DestinoSigla",
                table: "PrecoBase",
                column: "DestinoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoBase_OrigemSigla",
                table: "PrecoBase",
                column: "OrigemSigla");

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoBase_Aeroporto_DestinoSigla",
                table: "PrecoBase",
                column: "DestinoSigla",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrecoBase_Aeroporto_OrigemSigla",
                table: "PrecoBase",
                column: "OrigemSigla",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
