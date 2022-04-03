using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class CreateClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeronave_AeronaveId",
                table: "Voo");

            migrationBuilder.AlterColumn<int>(
                name: "AeronaveId",
                table: "Voo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Passageiro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeronave_AeronaveId",
                table: "Voo",
                column: "AeronaveId",
                principalTable: "Aeronave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeronave_AeronaveId",
                table: "Voo");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Endereco");

            migrationBuilder.AlterColumn<int>(
                name: "AeronaveId",
                table: "Voo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Passageiro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeronave_AeronaveId",
                table: "Voo",
                column: "AeronaveId",
                principalTable: "Aeronave",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
