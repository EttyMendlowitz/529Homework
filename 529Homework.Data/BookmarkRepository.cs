using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _529Homework.Data
{
    public class BookmarkRepository
    {
        private readonly string _connectionString;

        public BookmarkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBookmark(Bookmark b, int userId)
        {
            using var context = new AuthDbContext(_connectionString);


            var bookmark = context.Bookmarks.FirstOrDefault(bm => bm.Url == b.Url);
            int bookmarkId;

            if (bookmark == null)
            {
                b.Count = 1;
                context.Bookmarks.Add(b);
                context.SaveChanges();
                bookmarkId = b.Id;

            }
            else
            {
                bookmarkId = bookmark.Id;
                bookmark.Count += 1;
            }


            context.UsersBookmarks.Add(new UsersBookmarks
            {
                UserId = userId,
                BookmarkId = bookmarkId
            });
            context.SaveChanges();

        }

        public List<Bookmark> GetMostCount()
        {
            using var context = new AuthDbContext(_connectionString);
            var bookmarks = context.Bookmarks.FromSqlRaw("SELECT TOP (5) [Id],[Url], [Title], [Count] FROM Bookmarks ORDER BY COUNT DESC").ToList();
            return bookmarks;
        }

        public List<Bookmark> GetBookmarksForEmail(string email)
        {
            using var context = new AuthDbContext(_connectionString);
            var repo = new UserRepository(_connectionString);

            var user = repo.GetByEmail(email);

            var response =  context.Bookmarks.FromSqlRaw($"SELECT * FROM Bookmarks b\r\nJOIN UsersBookmarks ub\r\nON BookmarkId = b.id\r\nWHERE ub.userId = {user.Id}")
                .ToList();

            return response;

        }

        public void DeleteBookmark(int bookmarkId, int userId)
        {
            using var context = new AuthDbContext(_connectionString);

            context.Database.ExecuteSqlInterpolated($"DELETE FROM UsersBookmarks WHERE bookmarkId = {bookmarkId} AND UserId = {userId}");
            
            if (context.Bookmarks.FirstOrDefault(b => b.Id == bookmarkId).Count > 1)
            {
                context.Database.ExecuteSqlInterpolated($"UPDATE Bookmarks SET Count = Count - 1 WHERE Id = {bookmarkId}");
            }
            else
            {
                context.Database.ExecuteSqlInterpolated($"DELETE FROM Bookmarks WHERE id = {bookmarkId}");
            }
            context.SaveChanges();
        }

        public void UpdateBookmark (int userId, int id, string title)
        {
            using var context = new AuthDbContext(_connectionString);

            context.Database.ExecuteSqlInterpolated($"UPDATE Bookmarks SET Title = {title} WHERE Id = {id}");
        }
    }
}
