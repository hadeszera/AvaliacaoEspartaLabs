using Microsoft.EntityFrameworkCore.Migrations;

namespace AvaliacaoEspartaLabs.Infra.Migrations
{
    public partial class addPropPasswordOficina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Oficinas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Oficinas");
        }
    }
}
