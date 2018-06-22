using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Common;
using Model;
using System.IO;
using System.Data.Entity;
using SEEWeb.ViewModel;
using PagedList;


namespace SEEWeb.Controllers
{
    public class PictureController : Controller
    {
        SEEEntities db = new SEEEntities();
        PictureManager pm = new PictureManager();
        Picture_TypeManager ptm = new Picture_TypeManager();
        
        #region 图片主页
        public ActionResult Index(String pictureInfoFrom,string currentFilter,int? page)
        {
            var sort = db.Picture_Type.ToList();
            var pictures = from p in db.Picture.OrderByDescending(p => p.Pic_Time)

                           select p;
            if(pictureInfoFrom!=null)
            {
                page = 1;
            }
            else
            {
                pictureInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = pictureInfoFrom;

            if(!String.IsNullOrEmpty(pictureInfoFrom))
            {
                pictures = pictures.Where(x => x.Picture_Type.Name == pictureInfoFrom);
            }

            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var picturetype = new PictureViewModel()
            {
                Type1 = sort,
                Pictures = pictures.ToPagedList(pageNumber, pageSize),
            };
            return PartialView("Index",picturetype);
        }
        #endregion

        #region 后台管理
        public ActionResult List(int pageIndex=1)
        {
            var picture = pm.GetAll();
            //var picturetype = ptm.GetAll();
            //var picturemodel = from a in picture
            //                   join b in picturetype on a.Type_ID equals b.Type_ID
            //                   select new PictureViewModel
            //                   {
            //                       Pic_ID = a.Pic_ID,
            //                       User_ID = a.User_ID,
            //                       Pic_Pic = a.Pic_Pic,
            //                       Type_ID = b.Type_ID,
            //                       Pic_Mes = a.Pic_Mes,
            //                       Pic_Time = a.Pic_Time
            //                   };
            PagingHelper<Picture> PicturePaging = new PagingHelper<Picture>(5,picture); //初始化分页器以及显示数量
            PicturePaging.PageIndex = pageIndex; // 指定当前页
            return View(PicturePaging);//返回分页器实例到视图
        }
        #endregion

        #region 添加图片
        public ActionResult Create()
        {
            ViewBag.picturetype = new SelectList(ptm.GetAll(), "Type_ID", "Name");
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AfterCreate(Picture picture)
        {
            HttpPostedFileBase file = Request.Files["image"];
            if (picture!=null)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\pictures\") + fileName;
                    string relativepath = @"/images/pictures/" + fileName;
                    file.SaveAs(serverpath);
                    picture.Pic_Pic = relativepath;

                }
                picture.Pic_Time = DateTime.Now;
                picture.User_ID = Convert.ToInt32(Session["User_ID"].ToString());
                Picture addpicture = new Picture
                {
                    User_ID = picture.User_ID,
                    Pic_Pic = picture.Pic_Pic,
                    Type_ID = picture.Type_ID,
                    Pic_Mes = picture.Pic_Mes,
                    Pic_Time = picture.Pic_Time
                };
                var temp = pm.Add(addpicture);
                if(temp==true)
                {
                    return Content("<script>alert('上传成功！');window.open('" + Url.Action("Index", "Picture") + "','_self');</script>");
                }
                else
                {
                    return Content("上传失败");
                }
              
            }
            ViewBag.picturetype = new SelectList(ptm.GetAll(), "Type_ID", "Name");
            return View();
        }

        #endregion

        #region 删除图片
        public ActionResult Delete(int id)
        {
            var temp = pm.Remove(id);
            if (temp == true)
                return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "Picture") + "','_self');</script>");
            else
                return View();
        }

        public ActionResult Delete1(int id)
        {
            var temp = pm.Remove(id);
            if (temp == true)
                return Content("<script>;alert('删除成功!');history.go(-1)</script>");
            else
                return View();
        }
        #endregion

        #region 图片分页
        public ActionResult Picture(String typeInfoFrom,string currentFilter,int? page)
        {
            var pictures=from p in db.Picture.OrderByDescending(p=>p.Pic_Time)

                    select p;

            if(typeInfoFrom!=null)
            {
                page = 1;
            }
            else
            {
                typeInfoFrom = currentFilter;
            }
            ViewBag.CurrentFilter = typeInfoFrom;

            if(!String.IsNullOrEmpty(typeInfoFrom))
            {
                pictures = pictures.Where(x => x.Picture_Type.Name == typeInfoFrom);
            }

            int pageSize =12;
            int pageNumber = (page ?? 1);
            return View(pictures.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Picture1(int ?page)
        {
            var picture = from a in db.Picture.OrderByDescending(a => a.Pic_Time)
                          select a;
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(picture.ToPagedList(pageNumber, pageSize));
        }

        
        #endregion

        #region 图片详细
        public ActionResult Details ( int id)
        {
            
            Picture pictures = db.Picture.Find(id);
            Pic_Point pp = db.Pic_Point.Find(id);
            var picpoint = from p in db.Pic_Point.Where(p => p.Pic_ID == id)
                           select p;

            
            var pictures1 = from p in db.Picture.OrderByDescending(p => p.Pic_Time)
                            select p;
            var pic_comment = from pc in db.Pic_Comment.Where(p => p.Pic_ID == id).OrderByDescending(p => p.PC_Time)
                              select pc;
            var index = new SEEWeb.ViewModel.PictureViewModel()
            {
                Picture1 = pictures,
                Pictures = pictures1,
                Pic_Point = picpoint,
         
                Pic_Comment = pic_comment,
            };
             
            return View(index);
        }
        #endregion

        #region 图片点赞
        public ActionResult Point(Pic_Point picpoint,int Pic_ID)
        {
            if(Session["User_ID"]!=null)
            {
                var picture = db.Picture.Find(Pic_ID);
                int picid = Pic_ID;
                int User_ID= Convert.ToInt32(Session["User_ID"].ToString()); 

                var chk_member = db.Pic_Point.Where(o => o.User_ID == User_ID).Where(o => o.Pic_ID == picid).FirstOrDefault();
                if(chk_member==null)
                {
                  if (ModelState.IsValid)
                  {
                    picpoint.Pic_ID = picid;
                    picpoint.User_ID = User_ID;
                    picpoint.PP_Time = DateTime.Now;
                    db.Pic_Point.Add(picpoint);
                    db.SaveChanges();
                    return Content("<script>;alert('成功!');history.go(-1)</script>");
                  }
                }
                else
                {
                    return Content("<script>;alert('你已经点过赞了哦!');history.go(-1)</script>");
                }
            }
            else
            {
                return Content("<script>;alert('你还没登陆哦!');history.go(-1)</script>");
            }
            return Redirect("Details");
        }
        #endregion

    }
}