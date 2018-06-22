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
using Common;

namespace SEEWeb.Controllers
{
    public class Pic_CommentController : Controller
    {
        SEEEntities db = new SEEEntities();
        Pic_CommentManager pic_commentmanager = new Pic_CommentManager();
        // GET: Pic_Comment
        public ActionResult Index(int pageIndex=1)
        {
            var pc = db.Pic_Comment.Include(n => n.User).Include(n => n.Picture).ToList();
            PagingHelper<Pic_Comment> Pic_CommentPaging = new PagingHelper<Pic_Comment>(10, pc);
            Pic_CommentPaging.PageIndex = pageIndex;
            return View(Pic_CommentPaging);
            //return View(pc.ToList());

        }


        #region 发表图片评论
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comments(Pic_Comment piccomment)
        {
            if(Session["User_ID"]!=null)
            {
                   string textarea = Request["textarea"];
                  int Pic_ID = Convert.ToInt32(Request["picid"]);

                  if (ModelState.IsValid)
                  {
                piccomment.Pic_ID = Pic_ID;
                piccomment.User_ID = Convert.ToInt32(Session["User_ID"].ToString());
                piccomment.PC_Mes = textarea;
                piccomment.PC_Time = DateTime.Now;
                db.Pic_Comment.Add(piccomment);
                db.SaveChanges();
                return Content("<script>;alert('评论成功!');history.go(-1)</script>");

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