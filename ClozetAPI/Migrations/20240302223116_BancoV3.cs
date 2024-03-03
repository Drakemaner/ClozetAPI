using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClozetAPI.Migrations
{
    /// <inheritdoc />
    public partial class BancoV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_Usuario_UsuarioId",
                table: "Roupa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Roupa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_Usuario_UsuarioId",
                table: "Roupa",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_Usuario_UsuarioId",
                table: "Roupa");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Roupa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_Usuario_UsuarioId",
                table: "Roupa",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
