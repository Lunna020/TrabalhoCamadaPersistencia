using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrabalhoCamadaPersistencia.Migrations
{
    /// <inheritdoc />
    public partial class PrecoAtualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "animal",
                table: "Precos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "animal",
                table: "Precos");
        }
    }
}
