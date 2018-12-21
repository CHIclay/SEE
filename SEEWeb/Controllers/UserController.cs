using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using SEEWeb.Attributes;
using System.Data.Entity;
using SEEWeb.ViewModel;
using System.Net;
using PagedList;

namespace SEEWeb.Controllers
{
    [IsLogIn(IsCheck =false)]
    public class UserController : Controller
    {
        SEEEntities db = new SEEEntities();
        UserInfoManager usermanager = new UserInfoManager();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        #region 用户注册
        public ActionResult Register()
        {
            ViewBag.usersex = new SelectList(new string[] { "男"," 女" });
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserInfo user)
        {


            HttpPostedFileBase file = Request.Files["image1"];
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\users\") + fileName;
                    string relativepath = @"/images/users/" + fileName;
                    file.SaveAs(serverpath);
                    user.User_Img = relativepath;
                }
                user.User_Time = DateTime.Now;
                
                usermanager.InsertUser(user);
                Session["User_Name"] = user.User_Name;
                UserInfo users = usermanager.GetUserByName(user.User_Name);
                Session["UID"] = users.UID.ToString();
                Session["User_Img"] = users.User_Img;
                return Content("<script>alert('注册成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
            }
            ViewBag.usersex = new string[] { "男", " 女" };
            return View(user);


        }
        #endregion
        
        #region 用户名检测

        [HttpPost]
        public ActionResult CheckUser(string User_Name)
        {
            var result = usermanager.SelectUser(User_Name);
            ViewBag.Count = result.Count();
            if (result.Count() > 0)
            {
                return Content("<script>alert('用户民已存在');window.location.href = document.referrer;</script>");
            }
            else
            {
                return Content("<script>alert('该用户名可以使用');window.location.href = document.referrer;</script>");
            }
        }
        #endregion

        #region 用户登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserInfo user,string returnUrl)
        {
            int u = usermanager.Login(user);
            if(u>0)
            {
                Session["User_Name"] = user.User_Name; 
                UserInfo users = usermanager.GetUserByName(Session["User_Name"].ToString());
                Session["UID"] = users.UID;
                Session["User_Img"] = users.User_Img;
                if(returnUrl!=null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Content("<script>alert('登录成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
   
                }
            }
            else
            {
                return Content("<script>alert('用户名或密码错误！');window.open('" + Url.Content("~/User/Login") + "', '_self')</script>");
            }
        }
        #endregion

        #region 退出登录
        public ActionResult LoginOut()
        {
            Session["User_Name"] = null;
            return Content("<script>alert('账号退出成功');window.location.href = document.referrer;</script>");
        }
        #endregion

        #region 用户修改个人信息
        public ActionResult Edit(int id)
        {
            UserInfo user = usermanager.GetUserByID(id);
            ViewBag.usersex = new SelectList(new string[] { "男", " 女" });
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(UserInfo user)
        {
            HttpPostedFileBase file = Request.Files["image"];
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string filePath = file.FileName;
                        string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\images\users\") + fileName;
                        string relativepath = @"/images/users/" + fileName;
                        file.SaveAs(serverpath);
                        user.User_Img = relativepath;

                    }


                    user.User_Time = DateTime.Now;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Content("<script>alert('修改成功！');window.open('" + Url.Action("UserCenter", "User") + "','_self');</script>");

                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
            }
            ViewBag.usersex = new SelectList(new string[] { "男", " 女" });
            return View(user);
        }
        #endregion

        #region 用户List
        public ActionResult List(int? page,string search)
        {
            var list = new List<UserInfo>();
            if(search != null)
            {
                var users = (from p in db.UserInfo select p).Where(a => (a.User_Name.Contains(search)) || (a.User_Sex.Contains(search)) || (a.User_Pho.Contains(search)) || (a.User_Ema.Contains(search))).Where(a => a.User_Name != "此账号已关闭").ToList();
                list = users;
            }
            else
            {
                var users = (from p in db.UserInfo select p).Where(a => a.User_Name != "此账号已关闭").ToList();
                list = users;
            }           
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        #endregion

        #region 删除用户
        public ActionResult Delete(int id)
        {
            UserInfo user = db.UserInfo.Find(id);
            db.UserInfo.Remove(user);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "User") + "','_self');</script>");
        }
        #endregion

        #region 用户中心
        public ActionResult UserCenter()
        {
            if(Session["UID"]!=null)
            {
                int UID = Convert.ToInt32(Session["UID"].ToString());
                UserInfo user = db.UserInfo.Find(UID);
                return View(user);
            }
            else
            {
                return Content("<script>alert('你还没有登陆哦！');window.open('" + Url.Action("Login", "User") + "','_self');</script>"); 
            }
            
        }
        #endregion

        #region 用户主页
        public ActionResult UserIndex(int UID)
        {
            //int UID = Convert.ToInt32(Session["UID"].ToString());
            UserInfo user1 = db.UserInfo.Find(UID);
            var picture1 = (from p in db.Picture select p).OrderByDescending(p => p.Pic_Time).Where(p=>p.UID==UID).ToList().Take(10);
            var album1 = (from p in db.Album select p).OrderByDescending(p =>p.Alb_Time).Where(p=>p.UID==UID).ToList().Take(8);
            var album_save1 = (from p in db.Album_Save select p).OrderByDescending(p => p.AS_Time).Where(p=>p.UID==UID).ToList().Take(8);
            //var attention1 = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.UID == UID).ToList();
 
            var index = new SEEWeb.ViewModel.UserInfoViewModel
            {
                User1 = user1,
                Picture1 = picture1,
                Album1 = album1,
                Album_Save1 = album_save1,
                //Attention1 = attention1,
     
            };
            return View(index);
        }

        public ActionResult UserAttention1 (int UID)
        {
            UserInfo user1 = db.UserInfo.Find(UID);
            var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.UID == UID).ToList();
            var index = new SEEWeb.ViewModel.UserInfoViewModel
            {
                User1 = user1,
                Attention1 = attention,
            };
            return View(index);
        }

        public ActionResult UserAttention(int UID)
        {
            UserInfo user1 = db.UserInfo.Find(UID);
            var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.ToUID == UID).ToList();
            var index = new SEEWeb.ViewModel.UserInfoViewModel
            {
                User1 = user1,
                Attention2 = attention,
            };
            return View(index);
        }
        #endregion

        #region 用户关注
        public ActionResult attention(Attention atten, int ToUID)
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            var chk_member = db.Attention.Where(o => o.UID == UID).Where(o => o.ToUID == ToUID).FirstOrDefault();
            ViewBag.attentionde = chk_member;

            if (chk_member != null)
            {
                Attention attention = db.Attention.Remove(chk_member);
                db.SaveChanges();
                return Content("<script>;alert('取消关注成功！');history.go(-1)</script>");
            }
                atten.ToUID = Convert.ToInt32(ToUID);
                atten.UID = Convert.ToInt32(Session["UID"].ToString());
               
                atten.Att_Time = DateTime.Now;
                db.Attention.Add(atten);
                db.SaveChanges();

                return Content("<script>;alert('关注成功！');history.go(-1)</script>");
        }
        #endregion
        
        #region 用户收藏相册
        public ActionResult Save()
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            var save = (from p in db.Album_Save select p).OrderByDescending(p => p.AS_Time).Where(p => p.UID == UID).ToList();
            return View(save);
        }
        #endregion

        #region 关注我的
        public ActionResult focusme()
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            UserInfo user = db.UserInfo.Find(UID);
            var focusme = (from p in db.Attention select p).Where(p => p.ToUID == UID).ToList();
            return View(focusme);
        }
        #endregion

        #region 我关注的
        public ActionResult focus()
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            UserInfo user = db.UserInfo.Find(UID);
            var focus = (from p in db.Attention select p).Where(p => p.UID == UID).ToList();
            return View(focus);
        }
        #endregion

        #region 删除关注
        public ActionResult Delete_Att(int ? id)
        {
            Attention atten = db.Attention.Find(id);
            db.Attention.Remove(atten);
            db.SaveChanges();
            return RedirectToAction("focus");
        }
        #endregion

        #region 用户退出登录
        public ActionResult LogOff()
        {
            Session["User_Name"] = null;
            Session["UID"] = null;
            Session["User_Img"] = null;
            return Content("<script>alert('登出成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
        }
        #endregion

    }
}