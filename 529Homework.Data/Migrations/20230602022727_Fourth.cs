using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _529Homework.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookmarkUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_BookmarkUser_UsersId",
                table: "BookmarkUser",
                column: "UsersId");
        }
    }
}
