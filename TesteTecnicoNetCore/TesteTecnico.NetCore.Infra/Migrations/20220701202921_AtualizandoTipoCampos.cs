using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.NetCore.Data.Migrations
{
    public partial class AtualizandoTipoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "HistoricoEscolar",
                type: "varchar(55)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Formato",
                table: "HistoricoEscolar",
                type: "varchar(3)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Escolaridade",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "HistoricoEscolar",
                type: "varchar(90)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(55)");

            migrationBuilder.AlterColumn<string>(
                name: "Formato",
                table: "HistoricoEscolar",
                type: "varchar(90)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Escolaridade",
                type: "varchar(90)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }
    }
}
