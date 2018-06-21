using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Common;
using PagedList;
using SEEWeb.ViewModel;
using System.Net;
using System.Data.Entity;

namespace SEEWeb.Controllers
{
    public class AlbumController : Controller
    {
        AlbumManager albumm = new AlbumManager();
        Album_CommentManager albcm = new Album_CommentManager();
        SEEEntities db = new SEEEntities();
        #region 相册主页
        // GET: Album
        public ActionResult Index()
        {
            var album1 = (from p in db.Album select p).ToList().OrderByDescending(p => p.Album_Point.Count()).ToList();//显示点赞最多的八个相册
            
            return View(album1);   
        }
        #endregion

        #region 相册创建
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Album album)
        {
            HttpPostedFileBase file = Request.Files["albumimage"];
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\albums\") + fileName;
                    string relativepath = @"/images/albums/" + fileName;
                    file.SaveAs(serverpath);
                    album.Alb_Pic= relativepath;

                }
                album.User_ID= Convert.ToInt32(Session["User_ID"].ToString());
                
                album.Alb_Time = DateTime.Now;
                albumm.Add(album);
            
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("Index", "Album") + "','_self');</script>");
            }
            return View(album);
        }
        #endregion

        #region 相册主页实现分页
        public ActionResult Album(int ? page)
        {
            var album = (from p in db.Album select p).ToList().OrderByDescending(p => p.Album_Point.Count()).ToList();//根据点赞数排列;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(album.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Album1(int ? page)
        {
            var album = from a in db.Album.OrderByDescending(a => a.Alb_Time)
                        select a;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(album.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 相册详细
        public ActionResult Details(int id)
        { 
            Album albums = db.Album.Find(id);
            Album_Point ap = db.Album_Point.Find(id);
            var picture_in_album = from p in db.Picture_In_Album.Where(p => p.Alb_ID == id)
                          select p;
            //var pictures = (from p in db.Picture_In_Album select p).Where(p => p.Alb_ID == id).ToList();
            var albpoint = from p in db.Album_Point.Where(p => p.Alb_ID == id)
                           select p;
            var album1 = from a in db.Album.OrderByDescending(p => p.Alb_Time)
                         select a;
            var album_comment = from m in db.Album_Comment.Where(p => p.Alb_ID == id).OrderByDescending(p => p.AC_Time)
                                select m;
            var album_save = from m in db.Album_Save.Where(p => p.Alb_ID == id)
                             select m;
            var index = new SEEWeb.ViewModel.AlbumViewModel()
            {
                Album1 = albums,
                Album2 = album1,
                Album_Comment = album_comment,
                Album_Point = albpoint,
                Album_Save = album_save,
                Picture_In_Album=picture_in_album,
            };
            return View(index);
        }
        #endregion

        #region 相册评论
        [HttpPost]
        public ActionResult AC_Add(Album_Comment album_comment)
        {
            string acmes = Request["acmes"];
            int alb_id = Convert.ToInt32(Request["albid"]);
            
            if(ModelState.IsValid)
            {
                
                album_comment.Alb_ID = alb_id;
                album_comment.User_ID = Convert.ToInt32(Session["User_ID"].ToString());
                album_comment.AC_Mes = acmes;
                album_comment.AC_Time = System.DateTime.Now;
                db.Album_Comment.Add(album_comment);
                db.SaveChanges();
                return Content("<script>;alert('评论成功');history.go(-1)</script>");
            }
            return RedirectToAction("Details", "Album");
        }
        #endregion

        #region 相册点赞
        public ActionResult Point(Album_Point albpoint,int Alb_ID)
        {
            var album = db.Album.Find(Alb_ID);
            int albid = Alb_ID;
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            var chk_member = db.Album_Point.Where(p => p.User_ID == User_ID).Where(p => p.Alb_ID == albid).FirstOrDefault();
            if(chk_member==null)
            {
               if(ModelState.IsValid)
              {
                albpoint.Alb_ID = albid;
                albpoint.User_ID = User_ID;
                albpoint.AP_Time = DateTime.Now;
                db.Album_Point.Add(albpoint);
                db.SaveChanges();
                    //return Content("<script>alert('点赞成功！');window.open('" + Url.Action("Details", "Album") + "','_self');</script>");
                return Content("<script>;alert('成功!');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('你已经点过赞了哦！');history.go(-1)</script>");
            }

            return Redirect("Details");
        }
        #endregion

        #region 相册收藏
        public ActionResult Save(Album_Save albsave,int Alb_ID)
        {
            var album = db.Album.Find(Alb_ID);
            int albid = Alb_ID;
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            //var chk_member = db.Attention.Where(o => o.User_ID == User_ID).Where(o => o.To_User_ID == To_User_ID).FirstOrDefault();
            var chk_member = db.Album_Save.Where(p => p.User_ID == User_ID).Where(o => o.Alb_ID == albid).FirstOrDefault();
            if(chk_member==null)
            {
                 if (ModelState.IsValid)
               {
                albsave.Alb_ID = albid;
                albsave.User_ID = User_ID;
                albsave.AS_Time = DateTime.Now;
                db.Album_Save.Add(albsave);
                db.SaveChanges();
                return Content("<script>;alert('成功!');history.go(-1)</script>");
               } 
            }
            else
            {
                return Content("<script>;alert('你已经收藏过了哦!');history.go(-1)</script>");
            }
           
            return Redirect("Details");
        }
        #endregion

        #region 删除相册
        public ActionResult Delete(int id)
        {
            var temp = albumm.Remove(id);
            if (temp == true)
                return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "Album") + "','_self');</script>");
            else
                return View();
        }

        public ActionResult Delete1(int id)
        {
            var temp = albumm.Remove(id);
            if (temp == true)
                return Content("<script>;alert('删除成功!');history.go(-1)</script>");
            else
                return View();
        }
        #endregion


        #region 后台管理
        public ActionResult List(int pageIndex = 1)
        {
            //var album = db.Album.Include(n => n.Album_Point).Include(n=>n.Album_Save).ToList();
            var album = albumm.GetAll();
            PagingHelper<Album> AlbumPaging = new PagingHelper<Album>(5, album);
            AlbumPaging.PageIndex = pageIndex;
            return View(AlbumPaging);
        }

        #endregion
    }
}