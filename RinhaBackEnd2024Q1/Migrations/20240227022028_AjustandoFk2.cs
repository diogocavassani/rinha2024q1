using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RinhaBackEnd2024Q1.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoFk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Tracacoes",
                newName: "IdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Tracacoes_ClienteId",
                table: "Tracacoes",
                newName: "IX_Tracacoes_IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracacoes_cliente_IdCliente",
                table: "Tracacoes",
                column: "IdCliente",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracacoes_cliente_IdCliente",
                table: "Tracacoes");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Tracacoes",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Tracacoes_IdCliente",
                table: "Tracacoes",
                newName: "IX_Tracacoes_ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracacoes_cliente_ClienteId",
                table: "Tracacoes",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
