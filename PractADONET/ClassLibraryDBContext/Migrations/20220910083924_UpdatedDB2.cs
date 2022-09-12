using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryDBContext.Migrations
{
    public partial class UpdatedDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StyleGame_StyleGameId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleGame",
                table: "StyleGame");

            migrationBuilder.RenameTable(
                name: "StyleGame",
                newName: "StyleGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleGames",
                table: "StyleGames",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StyleGames_StyleGameId",
                table: "Games",
                column: "StyleGameId",
                principalTable: "StyleGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StyleGames_StyleGameId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StyleGames",
                table: "StyleGames");

            migrationBuilder.RenameTable(
                name: "StyleGames",
                newName: "StyleGame");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StyleGame",
                table: "StyleGame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StyleGame_StyleGameId",
                table: "Games",
                column: "StyleGameId",
                principalTable: "StyleGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
