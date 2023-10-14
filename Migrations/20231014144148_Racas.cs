using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoCamadaPersistencia.Migrations
{
    /// <inheritdoc />
    public partial class Racas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Racas",
               columns: table => new
               {
                   id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Raca = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Racas", x => x.id);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racas");
        }
    }
}
