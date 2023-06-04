using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _529Homework.Data
{
    public class UsersBookmarks
    {
        public int UserId { get; set; }
        public int BookmarkId { get; set; }

        public User User { get; set; }
        public Bookmark Bookmark { get; set; }
    }
}
