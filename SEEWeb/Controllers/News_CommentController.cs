using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Model;
using Common;

namespace SEEWeb.Controllers
{
    public class News_CommentController : Controller
    {
        private SEEEntities db = new SEEEntities();
        // GET: News_Comment
        public ActionResult Index(int pageIndex=1)
        {
            var newscomment = db.News_Comment.Include(n => n.User).Include(n => n.News).ToList();
            PagingHelper<News_Comment> NPPaging = new PagingHelper<News_Comment>(10, newscomment);
            NPPaging.PageIndex = pageIndex;
            return View(NPPaging);
        }
        #region 新闻评论详细
        public ActionResult Details(int?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Comment newscomment = db.News_Comment.Find(id);
            if(newscomment==null)
            {
                return HttpNotFound();
            }
            return View(newscomment);
        }
        #endregion

        #region 新闻评论删除 
        public ActionResult Delete(int?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News_Comment newscomment = db.News_Comment.Find(id);
            if(newscomment==null)
            {
                return HttpNotFound();
            }
            return View(newscomment);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News_Comment newscomment = db.News_Comment.Find(id);
            db.News_Comment.Remove(newscomment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}