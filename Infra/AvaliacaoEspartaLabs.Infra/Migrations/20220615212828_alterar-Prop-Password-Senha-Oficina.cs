using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoEspartaLabs.Infra.Migrations
{
    public partial class alterarPropPasswordSenhaOficina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Oficinas",
                newName: "Senha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Oficinas",
                newName: "Password");
        }
    }
}
