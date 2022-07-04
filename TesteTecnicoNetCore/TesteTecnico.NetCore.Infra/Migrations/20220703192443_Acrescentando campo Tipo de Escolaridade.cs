using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.NetCore.Data.Migrations
{
    public partial class AcrescentandocampoTipodeEscolaridade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "HistoricoEscolar",
                type: "varchar(55)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(55");

            migrationBuilder.AddColumn<int>(
                name: "TipoEscolaridade",
                table: "Escolaridade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEscolaridade",
                table: "Escolaridade");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "HistoricoEscolar",
                type: "varchar(55",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(55)");
        }
    }
}
