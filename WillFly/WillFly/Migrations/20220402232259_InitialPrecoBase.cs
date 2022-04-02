using Microsoft.EntityFrameworkCore.Migrations;

namespace WillFly.Migrations
{
    public partial class InitialPrecoBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PrecoBase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PrecoBase",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase",
                column: "DataInclusao");
        }
    }
}
