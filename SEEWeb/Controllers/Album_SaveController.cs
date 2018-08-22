using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace SEEWeb.Controllers
{
    public class Album_SaveController : Controller
    {
        SEEEntities db = new SEEEntities();
        // GET: Album_Save
        public ActionResult Index()
        {
            return View();
        }
        #region 删除相册收藏
        public ActionResult Delete(int id)
        { 
            int UID= Convert.ToInt32(Session["UID"].ToString());
            var chk_member = db.Album_Save.Where(o => o.UID == UID).Where(o => o.Alb_ID == id).FirstOrDefault();
            Album_Save album_save = db.Album_Save.Remove(chk_member);
            db.SaveChanges();
            return Content("<script>;alert('删除收藏成功！');history.go(-1)</script>");
        }
        #endregion 
      
    }
}