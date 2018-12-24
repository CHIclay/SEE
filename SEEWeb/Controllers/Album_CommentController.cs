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
        public ActionResult Index(int ? page,string search)
        {
            var list = new List<Album_Comment>();
            if (search != null)
            {
                var alc = (from p in db.Album_Comment select p).Where(a => (a.AC_Mes.Contains(search)) || (a.UserInfo.User_Name.Contains(search))).ToList();
                list = alc;
            }
            else
            {
                var alc = albcmanager.List();
                list = alc;
            }
           
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));  
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