using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSocioEconomico.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarImagenPerfilUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenPerfil",
                table: "Usuarios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Programas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenPerfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Programas");
        }
    }
}
