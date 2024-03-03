using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClozetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaCaminhoImagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "Roupa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "Roupa");
        }
    }
}
