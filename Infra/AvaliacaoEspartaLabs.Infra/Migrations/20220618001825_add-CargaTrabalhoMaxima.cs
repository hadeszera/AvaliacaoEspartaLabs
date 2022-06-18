using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoEspartaLabs.Infra.Migrations
{
    public partial class addCargaTrabalhoMaxima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "CargasTrabalho");

            migrationBuilder.AddColumn<int>(
                name: "CargaTrabalhoMaxima",
                table: "Oficinas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargaTrabalhoMaxima",
                table: "Oficinas");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "CargasTrabalho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
