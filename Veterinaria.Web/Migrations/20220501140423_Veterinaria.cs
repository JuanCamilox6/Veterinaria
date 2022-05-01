using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Web.Migrations
{
    public partial class Veterinaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "duenos",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barrio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_duenos", x => x.Documento);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaIngreso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreMascota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMascota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Alergias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascotas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_duenos_Documento",
                table: "duenos",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_Id",
                table: "mascotas",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "duenos");

            migrationBuilder.DropTable(
                name: "mascotas");
        }
    }
}
