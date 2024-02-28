using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinhaBackEnd2024Q1.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Tracacoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Tracacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
