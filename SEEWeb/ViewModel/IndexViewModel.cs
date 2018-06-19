﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Picture> Picture1 { get; set; }

        public IEnumerable<Picture> Picture2 { get; set; }

        public IEnumerable<News> News1 { get; set; }

        public IEnumerable<Album> Album { get; set; }

        public IEnumerable<User> User { get; set; }

        public IEnumerable<News_Comment> News_Comment { get; set; }

        

    }
}