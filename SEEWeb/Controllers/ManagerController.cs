using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using SEEWeb.Attributes;

namespace SEEWeb.Controllers
{
    public class ManagerController : Controller
    {
        private SEEEntities db = new SEEEntities();
        ManagerManager managermanager = new ManagerManager();
        // GET: Manager
        public ActionResult Index()
        {
            var managers = db.Manager;
            return View(managers.ToList());
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
        public ActionResult Delete(int ? id)
        {
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


    }
}