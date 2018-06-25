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
using Common;
 

namespace SEEWeb.Controllers
{
    [IsLogIn(IsCheck =false)]
    public class UserController : Controller
    {
        SEEEntities db = new SEEEntities();
        UserManager usermanager = new UserManager();
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
        public ActionResult Register(User user)
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
                User users = usermanager.GetUserByName(user.User_Name);
                Session["User_ID"] = users.User_ID.ToString();
                Session["User_Img"] = users.User_Img;
                return Content("<script>alert('注册成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
            }
            //else
            //{
            //    return Content("<script>alert('验证信息出错，注册失败！');window.open('" + Url.Action("Register", "User") + "','_self');</script>");
            //}
            ViewBag.usersex = new string[] { "男", " 女" };
            return View(user);


        }
        #endregion

        
        #region 用户名检测

        [HttpPost]
        public string CheckUser(string User_Name)
        {
            var result = usermanager.SelectUser(User_Name);
            if (result.Count() > 0)
            {
                return "用户名已存在，请重新输入!!";
            }
            else
            {
                return "该用户名未被注册，可以使用！";
            }
        }
        #endregion

        #region 用户登录
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user,string returnUrl)
        {
            int u = usermanager.Login(user);
            if(u>0)
            {
                Session["User_Name"] = user.User_Name; 
                User users = usermanager.GetUserByName(Session["User_Name"].ToString());
                Session["User_ID"] = users.User_ID;
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

        #region 用户异步登录
        public string AjaxLogin(string User_Name,string User_Pwd)
        {
            int result = usermanager.AjaxLogin(User_Name, User_Pwd);
            if(result>0)
            {
                User user = usermanager.GetUserByName(User_Name);
                Session["User_Name"] = User_Name;
                Session["User_ID"] = user.User_ID;
                return "登录成功.";
            }
            else
            {
                return "用户名或密码错误!";
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
            User user = usermanager.GetUserByID(id);
            ViewBag.usersex = new SelectList(new string[] { "男", " 女" });
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
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
        public ActionResult List(int pageIndex=1)
        {
            var um = usermanager.GetAll();
            PagingHelper<User> UserPaging = new PagingHelper<User>(10, um);
            UserPaging.PageIndex = pageIndex;
            return View(UserPaging);
             
        }
        #endregion

        #region 删除用户
        public ActionResult Delete(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "User") + "','_self');</script>");
        }
        #endregion

        #region 用户中心
        public ActionResult UserCenter()
        {
            if(Session["User_ID"]!=null)
            {
                int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
                User user = db.User.Find(User_ID);
                return View(user);
            }
            else
            {
                return Content("<script>alert('你还没有登陆哦！');window.open('" + Url.Action("Login", "User") + "','_self');</script>"); 
            }
            
        }
        #endregion

        #region 用户主页
        public ActionResult UserIndex(int User_ID)
        {
            //int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            User user1 = db.User.Find(User_ID);
            var picture1 = (from p in db.Picture select p).OrderByDescending(p => p.Pic_Time).Where(p=>p.User_ID==User_ID).ToList().Take(10);
            var album1 = (from p in db.Album select p).OrderByDescending(p =>p.Alb_Time).Where(p=>p.User_ID==User_ID).ToList().Take(8);
            var album_save1 = (from p in db.Album_Save select p).OrderByDescending(p => p.AS_Time).Where(p=>p.User_ID==User_ID).ToList().Take(8);
            //var attention1 = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.User_ID == User_ID).ToList();
 
            var index = new SEEWeb.ViewModel.UserViewModel
            {
                User1 = user1,
                Picture1 = picture1,
                Album1 = album1,
                Album_Save1 = album_save1,
                //Attention1 = attention1,
     
            };
            return View(index);
        }

        public ActionResult UserAttention1 (int User_ID)
        {
            User user1 = db.User.Find(User_ID);
            var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.User_ID == User_ID).ToList();
            var index = new SEEWeb.ViewModel.UserViewModel
            {
                User1 = user1,
                Attention1 = attention,
            };
            return View(index);
        }

        public ActionResult UserAttention(int User_ID)
        {
            User user1 = db.User.Find(User_ID);
            var attention = (from p in db.Attention select p).OrderBy(p => p.Att_Time).Where(p => p.To_User_ID == User_ID).ToList();
            var index = new SEEWeb.ViewModel.UserViewModel
            {
                User1 = user1,
                Attention2 = attention,
            };
            return View(index);
        }
        #endregion

        #region 用户关注
        public ActionResult attention(Attention atten, int To_User_ID)
        {
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            var chk_member = db.Attention.Where(o => o.User_ID == User_ID).Where(o => o.To_User_ID == To_User_ID).FirstOrDefault();
        
            if (chk_member != null)
            {
                Attention attention = db.Attention.Remove(chk_member);
                db.SaveChanges();
                return Content("<script>;alert('取消关注成功！');history.go(-1)</script>");
            }
            if (To_User_ID != null)
            {
                atten.To_User_ID = Convert.ToInt32(To_User_ID);
                atten.User_ID = Convert.ToInt32(Session["User_ID"].ToString());
               
                atten.Att_Time = DateTime.Now;
                db.Attention.Add(atten);
                db.SaveChanges();

                return Content("<script>;alert('关注成功！');history.go(-1)</script>");
            }
            ViewBag.attentionde = chk_member;
            return View(atten);
        }
        #endregion

        
        #region 用户收藏相册
        public ActionResult Save()
        {
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            var save = (from p in db.Album_Save select p).OrderByDescending(p => p.AS_Time).Where(p => p.User_ID == User_ID).ToList();
            return View(save);
        }
        #endregion

        #region 关注我的
        public ActionResult focusme()
        {
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            User user = db.User.Find(User_ID);
            var focusme = (from p in db.Attention select p).Where(p => p.To_User_ID == User_ID).ToList();
            return View(focusme);
        }
        #endregion

        #region 我关注的
        public ActionResult focus()
        {
            int User_ID = Convert.ToInt32(Session["User_ID"].ToString());
            User user = db.User.Find(User_ID);
            var focus = (from p in db.Attention select p).Where(p => p.User_ID == User_ID).ToList();
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
            Session["User_ID"] = null;
            Session["User_Img"] = null;
            return Content("<script>alert('登出成功！');window.open('" + Url.Action("Index", "Index") + "','_self');</script>");
        }
        #endregion

    }
}