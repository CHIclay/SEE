using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using SEEWeb.Attributes;
using System.Data.Entity;
using PagedList;
using System.Net;

namespace SEEWeb.Controllers
{
    public class NewsController : Controller
    {
        private SEEEntities db = new SEEEntities();
        NewsManager newsmanager = new NewsManager();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        #region 新闻添加
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(News news)
        {
            string mes = Request["News_Mes"];
            HttpPostedFileBase file = Request.Files["newsimage"];
            if (ModelState.IsValid)
            {
              
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\news\") + fileName;
                    string relativepath = @"/images/news/" + fileName;
                    file.SaveAs(serverpath);
                    news.News_Pic = relativepath;

                }
                news.News_Mes = mes;
                news.Man_ID = Convert.ToInt32(Session["Man_ID"].ToString());
                news.News_Time = DateTime.Now;
                newsmanager.InsertNews(news);
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("List", "News") + "','_self');</script>");
            }
            return View(news);
        }
        #endregion

        #region 新闻List
        public ActionResult List(int ? page)
        {
            var news = newsmanager.NList();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 新闻删除
        public ActionResult Delete(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "News") + "','_self');</script>");
        }
        #endregion

        #region 新闻修改
        public ActionResult Edit(int id)
        {
            News news = newsmanager.GetNewsByID(id);
            return View(news);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(News news)
        {
            string mes = Request["News_Mes"];
            HttpPostedFileBase file = Request.Files["newsimage"];
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string filePath = file.FileName;
                        string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\images\news\") + fileName;
                        string relativepath = @"/images/news/" + fileName;
                        file.SaveAs(serverpath);
                        news.News_Pic = relativepath;

                    }
                    news.News_Mes = mes;
                    news.Man_ID = Convert.ToInt32(Session["Man_ID"].ToString());
                    news.News_Time = DateTime.Now;
                    db.Entry(news).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("List", "News") + "','_self');</script>");

                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            return View(news);
        }
        #endregion

        #region 新闻主页实现分页
        public ActionResult News(int ? page)
        {
            var news = from m in db.News.OrderByDescending(p => p.News_Time)
                       select m;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }
        #region 新闻详细
        public ActionResult Details(int id)
        {
            News news = db.News.Find(id);
            var news1 = from m in db.News.OrderByDescending(p => p.News_Time) select m;
            var news_comment = from m in db.News_Comment.Where(p => p.News_ID == id).OrderByDescending(p => p.NC_Time) select m;
            var index = new SEEWeb.ViewModel.NewsViewModel()
            {
                News1 = news,
                News2 = news1,
                News_Comment = news_comment,
            };
            return View(index);
        }
        #endregion
        #endregion
 
        #region 新闻评论
        [HttpPost]
        public ActionResult NC_Add(News_Comment news_comment)
        {
            if(Session["UID"]!=null)
            {
                string pcmes = Request["pcmes"];
                int pic_ID = Convert.ToInt32(Request["picid"]);

                  if (ModelState.IsValid)
                 {
                news_comment.News_ID = pic_ID;
                news_comment.UID = Convert.ToInt32(Session["UID"].ToString());
                news_comment.NC_Mes = pcmes;
                news_comment.NC_Time = System.DateTime.Now;
                db.News_Comment.Add(news_comment);
                db.SaveChanges();
                return Content("<script>;alert('评论成功');history.go(-1)</script>");
                }
               return RedirectToAction("Details", "News");
            }
            else
            {
                return Content("<script>;alert('你还没有登录哦');history.go(-1)</script>");
            }
        }

        #endregion

        #region 管理员查看新闻详细
        public ActionResult Details2(int?id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if(news==null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        #endregion


    }
}