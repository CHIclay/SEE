using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class AlbumViewModel
    {
        public Album Album1 { get; set; }

        public IEnumerable<Album> Album2 { get; set; }

        public IEnumerable<Album_Comment> Album_Comment { get; set; }

        public IEnumerable<Album_Point> Album_Point { get; set; }

        public IEnumerable<Album_Save> Album_Save { get; set; }

        public IEnumerable<Picture_In_Album> Picture_In_Album { get; set; }

        public Picture Picture { get; set; }
     }
}