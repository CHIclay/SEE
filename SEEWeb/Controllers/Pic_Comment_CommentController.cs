using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using System.Data.Entity;
using PagedList;

namespace SEEWeb.Controllers
{
    public class Pic_Comment_CommentController : Controller
    {
        SEEEntities db = new SEEEntities();
        // GET: Pic_Comment_Comment
        public ActionResult Index(int ? page)
        {
            var pcc = db.Pic_Comment_Comment.Include(n => n.UserInfo).Include(n => n.Pic_Comment).ToList();
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(pcc.ToPagedList(pageNumber, pageSize));
        }
        #region 评论回复
        public ActionResult ReplyComments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReplyComments(int PC_ID,Pic_Comment_Comment piccc)
        {
            string replytext = Request.Form["textarea1"];
            if(replytext=="")
            {
                return Content("<script>;alert('回复不能为空');history.go(-1)</script>");
            }
            else
            {
                int Pic_ID = Convert.ToInt32(Session["Pic_ID"]);
                int userid = Convert.ToInt32(Session["UID"]);
                piccc.PC_ID = PC_ID;
                piccc.UID = userid;
                piccc.PCC_Mes = replytext;
                piccc.PCC_Time = DateTime.Now;
                db.Pic_Comment_Comment.Add(piccc);
                db.SaveChanges();
                return Content("<script>;alert('回复成功!');history.go(-1)</script>");

            }
        }
        #endregion

        #region 评论回复删除
        public ActionResult Delete(int id)
        {
            Pic_Comment_Comment pcc = db.Pic_Comment_Comment.Find(id);
            db.Pic_Comment_Comment.Remove(pcc);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("Index", "Pic_Comment_Comment") + "','_self');</script>");
        }
        #endregion

    }
}