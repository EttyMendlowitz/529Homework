using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _529Homework.Data.Migrations
{
    public partial class Ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookmarkTitle",
                table: "UsersBookmarks");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Bookmarks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Bookmarks");

            migrationBuilder.AddColumn<string>(
                name: "BookmarkTitle",
                table: "UsersBookmarks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
