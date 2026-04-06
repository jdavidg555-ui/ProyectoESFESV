using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProyectoSocioEconomico.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCatalogosBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Proyectos de construcción, vías, agua y saneamiento", "Activo", "Infraestructura" },
                    { 2, "Conservación ambiental, reforestación y ecología", "Activo", "Naturaleza" },
                    { 3, "Educación, becas y formación académica", "Activo", "Educacion" },
                    { 4, "Salud, atención médica y bienestar", "Activo", "Salud" },
                    { 5, "Ayuda humanitaria en emergencias y desastres", "Activo", "Desastres naturales" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Usuario que realiza donaciones a casos y programas", "Activo", "Donante" },
                    { 2, "Usuario que crea casos y recibe ayuda", "Activo", "Beneficiario" },
                    { 3, "Administrador del sistema con acceso total", "Activo", "Administrador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
