using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using SEEWeb.ViewModel;
using BLL;


namespace SEEWeb.Controllers
{
    public class IndexController : Controller
    {
        SEEEntities db = new SEEEntities();
        // GET: Index
        public ActionResult Index()
        {
            var picture1 = (from p in db.Picture select p).OrderByDescending(p => p.Pic_Time).Take(6);//显示最新的十张图片
            var picture2 = (from p in db.Picture select p).OrderByDescending(p => p.Pic_Point.Count()).ToList().Take(8);//显示点赞数最多的八张图片
            var news1 = (from p in db.News select p).ToList().OrderByDescending(p => p.News_Time).ToList().Take(1);//显示最新的第一条新闻
            var news2 = (from p in db.News select p).ToList().OrderByDescending(p => p.News_Time).ToList().Skip(1).Take(1);//显示最新的第二条新闻
            var news3= (from p in db.News select p).ToList().OrderByDescending(p => p.News_Time).ToList().Skip(2).Take(1);//显示最新的第三条新闻
            var news4 = (from p in db.News select p).ToList().OrderByDescending(p => p.News_Time).ToList().Skip(3).Take(1);//显示最新的第四条新闻
            var news5 = (from p in db.News select p).ToList().OrderByDescending(p => p.News_Time).ToList().Skip(4).Take(1);//显示最新的第五条新闻
            var album1 = (from p in db.Album select p).ToList().OrderByDescending(p => p.Album_Point.Count()).ToList().Take(6);//显示点赞最多的八个相册
            var user1 = (from p in db.User select p).ToList();
            var news_comment1 = (from p in db.News_Comment select p).ToList();
            var index = new SEEWeb.ViewModel.IndexViewModel()
            {
                Picture1 = picture1,
                Picture2 = picture2,
                News1 = news1,
                News2=news2,
                News3=news3,
                News4=news4,
                News5=news5,
                Album = album1,
                User=user1,
                News_Comment=news_comment1,
            };
            return View(index);
        }
    }
}