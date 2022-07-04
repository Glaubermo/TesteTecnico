using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteTecnico.NetCore.Data.Migrations
{
    public partial class RemovercampoTipodeEscolaridadedesnecessario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEscolaridade",
                table: "Escolaridade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEscolaridade",
                table: "Escolaridade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
