using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace SEEWeb.ViewModel
{
    public class ActivityDetailViewModel
    {
        public Activity Activity1 { get; set; }

        public IEnumerable<Activity> Activity2 { get; set; }

        public IEnumerable<PicInActivity> PicInActivity { get; set; }

        public IEnumerable<ActPicture> ActPicture1 { get; set; }

        public ActPicture ActPicture2 { get; set; }

        public PicInActivity First { get; set; }

        public PicInActivity Second { get; set; }

        public PicInActivity Third { get; set; }
    }
}