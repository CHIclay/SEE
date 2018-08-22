using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEEWeb.ViewModel;
using PagedList;
using BLL;
using Model;
using System.Data.Entity;

namespace SEEWeb.Controllers
{
    public class Picture_In_AlbumController : Controller
    {
        SEEEntities db = new SEEEntities();
        // GET: Picture_In_Album
        public ActionResult Index(int id)
        {
            Album album = db.Album.Find(id);
            var pictures = (from p in db.Picture_In_Album select p).Where(p => p.Alb_ID == id).ToList();
            return View(pictures);
        }

        #region 添加图片进相册
        public ActionResult Add(int Pic_ID)
        {
            int userid = Convert.ToInt32(Session["UID"].ToString());
            
            var album = from p in db.Album.Where(p => p.UID == userid)
                        select p;
            var picture = db.Picture.Find(Pic_ID);
            
                          

            var pictureinalbum = new ViewModel.AlbumViewModel
            {
                Album2 = album,
                Picture=picture,
            };
            return View(pictureinalbum); 

        }
        
        public ActionResult Add2(Picture_In_Album pia,int albid,int picid)
        {
           if(Session["UID"]!=null)
            {
                if (ModelState.IsValid)
                {
                pia.Alb_ID = albid;
                pia.Pic_ID = picid;
                pia.PIA_Time = DateTime.Now;
                db.Picture_In_Album.Add(pia);
                db.SaveChanges();
                return Content("<script>;alert('添加成功');history.go(-2)</script>");
                }
                  return RedirectToAction("Details", "Picture");
            }
            else
            {
                return Content("<script>;alert('你还没有登陆哦!');history.go(-1)</script>");
            }
         
           
        }
        #endregion
    }
}