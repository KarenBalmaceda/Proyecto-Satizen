using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Satizen_Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institucion",
                columns: table => new
                {
                    idInstitucion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccionInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefonoInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correoInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celularInstitucion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucion", x => x.idInstitucion);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institucion");
        }
    }
}
