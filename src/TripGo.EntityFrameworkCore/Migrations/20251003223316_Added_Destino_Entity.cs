using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripGo.Migrations
{
    /// <inheritdoc />
    public partial class Added_Destino_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDestinos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Poblacion = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Coordenadas = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CantidadBusquedas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDestinos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDestinos");
        }
    }
}
