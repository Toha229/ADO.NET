using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassLibraryDBContext.Migrations
{
    public partial class UpdatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StyleGame",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "StyleGameId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StyleGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleGame", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_StyleGameId",
                table: "Games",
                column: "StyleGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_StyleGame_StyleGameId",
                table: "Games",
                column: "StyleGameId",
                principalTable: "StyleGame",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_StyleGame_StyleGameId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "StyleGame");

            migrationBuilder.DropIndex(
                name: "IX_Games_StyleGameId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "StyleGameId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "StyleGame",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
