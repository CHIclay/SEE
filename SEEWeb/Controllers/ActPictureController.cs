using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace SEEWeb.Controllers
{
    public class ActPictureController : Controller
    {
        ActPictureManager apm = new ActPictureManager();
        SEEEntities db = new SEEEntities();

        // GET: ActPicture
        public ActionResult Index(int id)
        {
            ActPicture ap = apm.GetById(id);
            return View(ap);
        }
        #region 设置第一名
        public ActionResult SetF(int acid,int apid)
        {
            var piaaa = (from u in db.PicInActivity
                         where u.Num==1
                         select u);
            int cou = piaaa.Count();
            if(cou == 0)
            {
                PicInActivity piaa = (from u in db.PicInActivity
                                      where u.Ac_ID == acid && u.AP_ID == apid
                                      select u).FirstOrDefault();
                if (piaa != null)
                {
                    PicInActivity pia = db.PicInActivity.Find(piaa.PIAC_ID);
                    pia.Num = 1;
                    db.SaveChanges();
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('已经有第一了哦');history.go(-1)</script>");
            }
           
            return View();
        }
        #endregion

        #region 设置第二名
        public ActionResult SetS(int acid, int apid)
        {
            var piaaa = (from u in db.PicInActivity
                         where u.Num == 2
                         select u);
            int cou = piaaa.Count();
            if (cou == 0)
            {
                PicInActivity piaa = (from u in db.PicInActivity
                                      where u.Ac_ID == acid && u.AP_ID == apid
                                      select u).FirstOrDefault();
                if (piaa != null)
                {
                    PicInActivity pia = db.PicInActivity.Find(piaa.PIAC_ID);
                    pia.Num = 2;
                    db.SaveChanges();
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('已经有第二了哦');history.go(-1)</script>");
            }

            return View();
        }
        #endregion

        #region 设置第三名
        public ActionResult SetT(int acid, int apid)
        {
            var piaaa = (from u in db.PicInActivity
                         where u.Num == 3
                         select u);
            int cou = piaaa.Count();
            if (cou == 0)
            {
                PicInActivity piaa = (from u in db.PicInActivity
                                      where u.Ac_ID == acid && u.AP_ID == apid
                                      select u).FirstOrDefault();
                if (piaa != null)
                {
                    PicInActivity pia = db.PicInActivity.Find(piaa.PIAC_ID);
                    pia.Num = 3;
                    db.SaveChanges();
                    return Content("<script>;alert('添加成功');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('已经有第三了哦');history.go(-1)</script>");
            }

            return View();
        }
        #endregion

        #region 取消名次
        public ActionResult SetNon(int acid,int apid)
        {
            PicInActivity piaa = (from u in db.PicInActivity
                                  where u.Ac_ID == acid && u.AP_ID == apid
                                  select u).FirstOrDefault();
            PicInActivity pia = db.PicInActivity.Find(piaa.PIAC_ID);
            pia.Num = 0;
            db.SaveChanges();
            return Content("<script>;alert('取消成功');history.go(-1)</script>");
        }
        #endregion
    }
}