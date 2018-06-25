using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class ManagerDetailsViewModel
    {
        public IEnumerable<Picture> Picture1 { get; set; }
        public IEnumerable<Pic_Point> Pic_Point1 { get; set; }
        public IEnumerable<News> News1 { get; set; }
        public IEnumerable<Album> Album1 { get; set; }
        public IEnumerable<Album_Point> Album_Point1 { get; set; }
    }
}