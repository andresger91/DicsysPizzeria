using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class Inicio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Ingrediente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_nombre",
                table: "Pizza",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_nombre",
                table: "Ingrediente",
                column: "nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pizza_nombre",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_nombre",
                table: "Ingrediente");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Ingrediente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
