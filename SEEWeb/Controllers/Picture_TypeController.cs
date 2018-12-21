using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using PagedList;
 

namespace SEEWeb.Controllers
{
    public class Picture_TypeController : Controller
    {
        SEEEntities db = new SEEEntities();
        BLL.Picture_TypeManager ptmanager = new BLL.Picture_TypeManager();
        #region 图片类别分页
        public ActionResult Index(int ? page,string search)
        {
            var list = new List<Picture_Type>();
            if(search != null)
            {
                var pt = (from p in db.Picture_Type select p).Where(a => a.Name.Contains(search)).ToList();
                list = pt;
            }else{
                var pt = ptmanager.List();
                list = pt;
            }            
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 添加
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Picture_Type pt)
        {
          if (ModelState.IsValid)
          {
             Picture_Type @type = new Picture_Type
            {
                Name = pt.Name
            };
            var temp = ptmanager.Add(@type);
            if (temp == true)
            {
                return RedirectToAction("Index");
            }
          }
           
            return View(pt);
        }
        #endregion

        #region 修改
        public ActionResult Edit(int id)
        {
            Picture_Type pt = ptmanager.SelectID(id);
            return View(pt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Picture_Type pt)
        {
            ptmanager.Edit(pt);
            return RedirectToAction("Index");
        }
        #endregion

        #region 删除
        public ActionResult Delete(int id)
        {
            ptmanager.DeleteID(id);
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Picture_Type") + "','_self');</script>");
        }
        #endregion
    }
}