using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using System.Data.Entity;
using Common;
using PagedList;

namespace SEEWeb.Controllers
{
    public class Album_CommentController : Controller
    {
        SEEEntities db = new SEEEntities();
        Album_CommentManager albcmanager = new Album_CommentManager();
        // GET: Album_Comment
        public ActionResult Index(int ? page)
        {
            var alc = albcmanager.List();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(alc.ToPagedList(pageNumber, pageSize));  
        }

        #region 相册评论删除
        public ActionResult Delete(int id)
        {
            Album_Comment ac = db.Album_Comment.Find(id);
            db.Album_Comment.Remove(ac);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Album_Comment") + "','_self');</script>");
        }
        #endregion
    }
}