﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _529Homework.Data
{
    public class Bookmark
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string Title { get; set; }
        public int Count { get; set; }

        [JsonIgnore]
        public List<UsersBookmarks> UsersBookmarks{ get; set; }
    }
}
