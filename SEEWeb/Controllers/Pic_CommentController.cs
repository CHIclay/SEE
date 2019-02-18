using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using PagedList;
using SEEWeb.ViewModel;
using System.Data.Entity;

namespace SEEWeb.Controllers
{
    public class Pic_CommentController : Controller
    {
        SEEEntities db = new SEEEntities();
        Pic_CommentManager pic_commentmanager = new Pic_CommentManager();
        // GET: Pic_Comment
        public ActionResult Index(int ? page,string search)
        {
            var list = new List<Pic_Comment>();
            if(search != null)
            {
                var pcs = (from p in db.Pic_Comment select p).Where(a => (a.PC_Mes.Contains(search)) || (a.UserInfo.User_Name.Contains(search))).ToList();
                list = pcs;
            }
            else
            {
                var pcs = pic_commentmanager.List();
                list = pcs;
            }            
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }


        #region 发表图片评论
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comments(Pic_Comment piccomment)
        {
            if(Session["UID"]!=null)
            {
                string textarea = Request["textarea"];
                int Pic_ID = Convert.ToInt32(Request["picid"]);
                Session["Pic_ID"] = Pic_ID;
                if (ModelState.IsValid)
                {
                    piccomment.Pic_ID = Pic_ID;
                    piccomment.UID = Convert.ToInt32(Session["UID"].ToString());
                    piccomment.PC_Mes = textarea;
                    piccomment.PC_Time = DateTime.Now;
                    db.Pic_Comment.Add(piccomment);
                    db.SaveChanges();
                    return Content("<script>alert('评论成功！');window.open('" + Url.Action("Details", "Picture",new { id = Pic_ID }) + "','_self');</script>");
                  }
            }
            else
            {
                return Content("<script>;alert('你还没有登陆哦!');history.go(-1)</script>");
            }
           
            return RedirectToAction("Details", "Picture");
        }
        #endregion

        #region 图片评论删除
        public ActionResult Delete(int id)
        {
            Pic_Comment pc = db.Pic_Comment.Find(id);
            db.Pic_Comment.Remove(pc);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Pic_Comment") + "','_self');</script>");
        }
        #endregion
    }
}