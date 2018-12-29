using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardTrade.Data.Migrations
{
    public partial class uniqueslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "BoardGames",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Slug",
                table: "BoardGames",
                column: "Slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BoardGames_Slug",
                table: "BoardGames");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "BoardGames",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
