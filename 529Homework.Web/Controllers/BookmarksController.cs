using _529Homework.Data;
using _529Homework.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _529Homework.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly string _connectionString;

        public BookmarksController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [Route("addbookmark")]
        [HttpPost]
        [Authorize]
        public void AddBookmark(BookmarkViewModel bvm)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.AddBookmark(bvm, bvm.User.Id);
        }

        [Route("getbookmarks")]
        [HttpGet]
        [Authorize]
        public List<Bookmark> GetBookmarks()
        {
            var repo = new BookmarkRepository(_connectionString);
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }
            return repo.GetBookmarksForEmail(User.Identity.Name);
        }


        [Route("gettopbookmarks")]
        [HttpGet]
        public List<Bookmark> GetTopBookmarks()
        {
            var repo = new BookmarkRepository(_connectionString);
            return repo.GetMostCount();
        }

        [Route("deletebookmark")]
        [HttpPost]
        [Authorize]
        public void DeleteBookmark(BookmarkViewModel bvm)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.DeleteBookmark(bvm.Id, bvm.User.Id);
        }

        [Route("updatebookmark")]
        [HttpPost]
        [Authorize]
        public void UpdateBookmark(BookmarkViewModel bvm)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.UpdateBookmark(bvm.User.Id, bvm.Id, bvm.Title);
        }
    }
}
