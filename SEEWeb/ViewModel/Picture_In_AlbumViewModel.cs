using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
namespace SEEWeb.ViewModel
{
    public class Picture_In_AlbumViewModel
    {
        public Picture_In_Album Picture_In_Album1 { get; set; }

        public IEnumerable<Picture_In_Album> Picture_In_Album2 { get; set; }

        public IEnumerable<Picture> Picture { get; set; }

        public IEnumerable<Album> Album { get; set; }
    }
}