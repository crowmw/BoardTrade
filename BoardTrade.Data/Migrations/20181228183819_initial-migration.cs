using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BoardTrade.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ThumbnailUrl = table.Column<string>(nullable: true),
                    MinPlayers = table.Column<int>(nullable: false),
                    MaxPlayers = table.Column<int>(nullable: false),
                    PlayingTime = table.Column<int>(nullable: false),
                    IsExpansion = table.Column<bool>(nullable: false),
                    YearPublished = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    AverageRating = table.Column<float>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    TimeOfCreation = table.Column<DateTime>(nullable: false),
                    TimeOfModification = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersBoardGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BoardGameId = table.Column<Guid>(nullable: false),
                    Condition = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Unwanted = table.Column<bool>(nullable: false),
                    Wanted = table.Column<bool>(nullable: false),
                    ForSale = table.Column<bool>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ForExchange = table.Column<bool>(nullable: false),
                    Shipping = table.Column<bool>(nullable: false),
                    ShippingPrice = table.Column<float>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    TimeOfCreation = table.Column<DateTime>(nullable: false),
                    TimeOfModification = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBoardGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersBoardGames_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersBoardGames_BoardGameId",
                table: "UsersBoardGames",
                column: "BoardGameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersBoardGames");

            migrationBuilder.DropTable(
                name: "BoardGames");
        }
    }
}
