using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class SearchViewModel
    {
        public IEnumerable<Picture> picture { get; set; }
        public IEnumerable<Album> album { get; set; }
        public IEnumerable<News> news { get; set; }
        public IEnumerable<Activity> activity { get; set; }
    }
}