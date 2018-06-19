using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class NewsViewModel
    {
        public News News1 { get; set; }

        public IEnumerable<News> News2 { get; set; }

        public IEnumerable<News_Comment> News_Comment { get; set; }
    }
}