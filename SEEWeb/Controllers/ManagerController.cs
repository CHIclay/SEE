using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Common;
using SEEWeb.Attributes;
using SEEWeb.ViewModel;
using PagedList;

namespace SEEWeb.Controllers
{
    public class ManagerController : Controller
    {
        private SEEEntities db = new SEEEntities();
        ManagerManager managermanager = new ManagerManager();
        // GET: Manager
        public ActionResult Index(int ? page)
        {
            var man = managermanager.List();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(man.ToPagedList(pageNumber, pageSize));
        }
        #region 管理员登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Manager manager,string returnUrl)
        {
            int u = managermanager.Login(manager);
            if (u>0)
            {
                Session["Man_Name"] = manager.Man_Name;
                Manager managers = managermanager.GetManagerByName(Session["Man_Name"].ToString());
                Session["Man_ID"] = managers.Man_ID;
                if(returnUrl!=null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Content("<script>alert('登录成功！');window.open('" + Url.Action("Index", "Manager") + "','_self');</script>");
                }
            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/Manager/Login") + "', '_self')</script>");
            }
        }
        #endregion

        #region 管理员退出登录
        public ActionResult LogOff()
        {
            Session["Man_Name"] = null;
            Session["Man_ID"] = null;
            return RedirectToAction("Index", "Index");
        }
        #endregion

        #region 管理员添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Manager manager)
        {
            if(ModelState.IsValid)
            {
                manager.Man_Time = DateTime.Now;
                managermanager.InsertManager(manager);
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index", "Manager") + "','_self');</script>");
            }
           
            return View(manager);
        }
        #endregion

        #region 删除管理员
        public ActionResult Delete(int id)
        {
           
            //News news = (from u in db.News where u.Man_ID == id select u).FirstOrDefault();
            //int news_id = news.News_ID;
            //News news1 = db.News.Find(news_id);
            //db.News.Remove(news1);
            //db.SaveChanges();


            Manager manager = db.Manager.Find(id);
            db.Manager.Remove(manager);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Manager") + "','_self');</script>");
            
        }

        #endregion

        #region 修改管理员
        public ActionResult Edit(int id)
        {
            Manager manager = managermanager.GetManagerByID(id);
            return View(manager);
        }
        [HttpPost]
        public ActionResult Edit(Manager manager)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    manager.Man_Time = DateTime.Now;
                    db.Entry(manager).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("Index", "Manager") + "','_self');</script>");
                }
                catch(Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(manager);
        }
        #endregion

        #region 管理员查看站内信息
        public ActionResult ManagerDetails()
        {
            var picture1 = (from p in db.Picture select p).ToList();
            var pic_point1 = (from p in db.Pic_Point select p).ToList();
            var album1=(from p in db.Album select p).ToList();
            var album_point1 = (from p in db.Album_Point select p);
            var news1 = (from p in db.News select p).ToList();
            var index = new SEEWeb.ViewModel.ManagerDetailsViewModel()
            {
                Picture1 = picture1,
                Pic_Point1 = pic_point1,
                Album1 = album1,
                Album_Point1 = album_point1,
                News1 = news1,
            };
            return View(index);

        }
        #endregion


    }
}