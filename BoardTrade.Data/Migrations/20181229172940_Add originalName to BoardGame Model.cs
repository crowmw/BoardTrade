using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardTrade.Data.Migrations
{
    public partial class AddoriginalNametoBoardGameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalName",
                table: "BoardGames",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalName",
                table: "BoardGames");
        }
    }
}
