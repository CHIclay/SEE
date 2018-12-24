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
                album.UID= Convert.ToInt32(Session["UID"].ToString());
                
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
            var album = (from p in db.Album select p).ToList().OrderByDescending(a=>a.Alb_Time).ToList();//根据点赞数排列;
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(album.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Album1(int ? page)
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            var album = from a in db.Album.OrderByDescending(a => a.Alb_Time).Where(p => p.UID == UID).ToList()
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
            int point = albums.Album_Point.Count();
            ViewBag.pc = point;
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
                album_comment.UID = Convert.ToInt32(Session["UID"].ToString());
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
        public JsonResult Point(Album_Point albpoint,int Alb_ID)
        {
            var list = new List<PointList>();
            var album = db.Album.Find(Alb_ID);
            int albid = Alb_ID;
            int UID = Convert.ToInt32(Session["UID"].ToString());
            int chk_member = db.Album_Point.Where(p => p.UID == UID).Where(p => p.Alb_ID == albid).Count();
            if(chk_member != 1)
            {
                if(ModelState.IsValid)
                {
                    albpoint.Alb_ID = albid;
                    albpoint.UID = UID;
                    albpoint.AP_Time = DateTime.Now;
                    db.Album_Point.Add(albpoint);
                    db.SaveChanges();
                }
            }
            var sum = db.Album_Point.Where(a => a.Alb_ID == albid).ToList().Count();
            for(int i = 1;i <= 1; i++)
            {
                PointList pl = new PointList();
                pl.sum = sum;
                pl.succ = chk_member;
                list.Add(pl);
            }
            return Json(list);
        }
        #endregion

        #region 相册收藏
        public JsonResult Save(Album_Save albsave,int Alb_ID)
        {
            var list = new List<PointList>();
            var album = db.Album.Find(Alb_ID);
            int albid = Alb_ID;
            int UID = Convert.ToInt32(Session["UID"].ToString());
            int chk_member = db.Album_Save.Where(p => p.UID == UID).Where(p => p.Alb_ID == albid).Count();
            if(chk_member != 1)
            {
                if (ModelState.IsValid)
                {
                    albsave.Alb_ID = albid;
                    albsave.UID = UID;
                    albsave.AS_Time = DateTime.Now;
                    db.Album_Save.Add(albsave);
                    db.SaveChanges();
                }
            }
            var sum = db.Album_Save.Where(a => a.Alb_ID == albid).ToList().Count();
            for(int i = 1;i <= 1; i++)
            {
                PointList pl = new PointList();
                pl.sum = sum;
                pl.succ = chk_member;
                list.Add(pl);
            }
            return Json(list);
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
        public ActionResult List(int ? page,string search)
        {
            var list = new List<Album>();
            if(search != null)
            {
                var alb = (from p in db.Album select p).Where(a => (a.Alb_Name.Contains(search)) || (a.Alb_Mes.Contains(search)) || (a.UserInfo.User_Name.Contains(search))).ToList();
                list = alb;
            }
            else
            {
                var alb = albumm.List();
                list = alb;
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        #endregion
    }
}