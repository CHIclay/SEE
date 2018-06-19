using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;

namespace SEEWeb.ViewModel
{
    public class PictureViewModel
    {
        public IEnumerable<Picture_Type> Type1 { get; set; }

      

        public IEnumerable<Picture> Pictures { get; set; }
        
        public Picture Picture1 { get; set; }

        public IEnumerable<Pic_Comment> Pic_Comment { get; set; }

        public  IEnumerable<Pic_Comment_Comment> Pic_Comment_Comment { get; set; }

        public IEnumerable<Pic_Point> Pic_Point { get; set; }
      
    }
}