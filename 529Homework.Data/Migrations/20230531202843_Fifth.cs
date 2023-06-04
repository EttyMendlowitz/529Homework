using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _529Homework.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookmarks");

            migrationBuilder.CreateTable(
                name: "BookmarkUser",
                columns: table => new
                {
                    BookmarksId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookmarkUser", x => new { x.BookmarksId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_BookmarkUser_Bookmarks_BookmarksId",
                        column: x => x.BookmarksId,
                        principalTable: "Bookmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookmarkUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersBookmarks",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookmarkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBookmarks", x => new { x.UserId, x.BookmarkId });
                    table.ForeignKey(
                        name: "FK_UsersBookmarks_Bookmarks_BookmarkId",
                        column: x => x.BookmarkId,
                        principalTable: "Bookmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersBookmarks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookmarkUser_UsersId",
                table: "BookmarkUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBookmarks_BookmarkId",
                table: "UsersBookmarks",
                column: "BookmarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookmarkUser");

            migrationBuilder.DropTable(
                name: "UsersBookmarks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bookmarks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Users_UserId",
                table: "Bookmarks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
