using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class UserViewModel
    {
        public User User1 { get; set; }

        public IEnumerable<Album> Album1 { get; set; }

        public IEnumerable<Album_Save> Album_Save1 { get; set; }

        public IEnumerable<Attention> Attention1 { get; set; }

        public IEnumerable<Attention> Attention2 { get; set; }

        public IEnumerable<Picture> Picture1 { get; set; }
 
            
    }
}