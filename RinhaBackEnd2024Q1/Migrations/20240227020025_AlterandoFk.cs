using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinhaBackEnd2024Q1.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Tracacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Tracacoes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Tracacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Tracacoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "id");
        }
    }
}
