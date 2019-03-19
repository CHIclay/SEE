using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using PagedList;
using Model;

namespace SEEWeb.Controllers
{
    public class ActivityController : Controller
    {
        ActivityManager am = new ActivityManager();
        ActPictureManager actpicm = new ActPictureManager();
        SEEEntities db = new SEEEntities();
        #region 相册主页
        // GET: Activity
        public ActionResult Index(int ? page)
        {
            var act = (from p in db.Activity select p).ToList().OrderBy(p => p.Ac_Sta_Time).ToList();//显示点赞最多的八个相册
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(act.ToPagedList(pageNumber,pageSize));
        }
        #endregion

        #region 活动发起
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Activity activity)
        {
            HttpPostedFileBase file = Request.Files["actimage"];
            
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filePath = file.FileName;
                    string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\images\activitys\") + fileName;
                    string relativepath = @"/images/activitys/" + fileName;
                    file.SaveAs(serverpath);
                    activity.Ac_Pic = relativepath;
                }
                activity.Ac_Name = Request["ActivityName"];
                activity.Ac_Mes = Request["ActivityMes"];
                DateTime startdate = Convert.ToDateTime(Request["startdate"]);
                DateTime endtime = Convert.ToDateTime(Request["stopdate"]);
                activity.Ac_Sto_Time = endtime;
                activity.Ac_Sta_Time = startdate;
                activity.IsAct = 1;
                am.Add(activity);
                return Content("<script>alert('添加成功！');window.open('" + Url.Action("List", "Activity") + "','_self');</script>");
            }
            return View(activity);
        }
        #endregion

        #region 活动查询
        public ActionResult List(int ? page,string search)
        {
            Session["User_Name"] = null;
            var list = new List<Activity>();
            if(search != null)
            {
                var acts = (from p in db.Activity select p).Where(a => (a.Ac_Mes.Contains(search)) || (a.Ac_Name.Contains(search))).ToList();
                list = acts;
            }
            else
            {
                var acts = am.List();
                list = acts;
            }        
            int pageSize = 9;
            int pageNumber=(page ?? 1);
            return View(list.ToPagedList(pageNumber,pageSize));
        }
        #endregion

        #region 活动删除
        public ActionResult Delete(int id)
        {
            var activity = am.Remove(id);
            if(activity==true)
                return Content("<script>alert('删除成功！');window.open('" + Url.Action("List", "Activity") + "','_self');</script>");
            else
                return View();
        }
        #endregion

        #region 活动详细
        public ActionResult Details(int id)
        {
            Activity activity1 = db.Activity.Find(id);
            var picinact = from p in db.PicInActivity.Where(p => p.Ac_ID == id)
                           select p;
            var activity2 = from p in db.Activity.OrderBy(p => p.Ac_Sta_Time)
                            select p;
            PicInActivity first = (from p in db.PicInActivity.Where(p => p.Num == 1).Where(a => a.Ac_ID==id) select p).FirstOrDefault();
            PicInActivity second = (from p in db.PicInActivity.Where(p => p.Num == 2).Where(a => a.Ac_ID == id) select p).FirstOrDefault();
            PicInActivity third = (from p in db.PicInActivity.Where(p => p.Num == 3).Where(a => a.Ac_ID == id) select p).FirstOrDefault();
            ViewBag.first = first;
            ViewBag.second = second;
            ViewBag.third = third;
            var index = new SEEWeb.ViewModel.ActivityDetailViewModel()
            {
                Activity1 = activity1,
                PicInActivity = picinact,
                Activity2 = activity2,
                First = first,
                Second=second,
                Third=third,
            };
            return View(index);
        }
        #endregion

        #region 参与活动
        public ActionResult Attend()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Attend(ActPicture actpic,PicInActivity picinact)
        {
            int id=Convert.ToInt32(Request["Ac_ID"]);
            Activity act = (from p in db.Activity where p.Ac_ID == id select p).FirstOrDefault();
            if (act.IsAct != 0)
            {
             if (Session["UID"] != null)
             {
                HttpPostedFileBase file = Request.Files["img"];
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        string filePath = file.FileName;
                        string fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                        string serverpath = Server.MapPath(@"\images\actpic\") + fileName;
                        string relativepath = @"/images/actpic/" + fileName;
                        file.SaveAs(serverpath);
                        actpic.AP_Pic = relativepath;
                        actpic.UID = Convert.ToInt32(Session["UID"].ToString());
                        actpic.AP_Mes = Request["Mes"];
                        actpic.AP_Time = DateTime.Now;
                        actpicm.Add(actpic);
                        string ap_id = actpic.AP_ID.ToString();
                        picinact.Ac_ID = Convert.ToInt32(Request["Ac_ID"]);
                        picinact.AP_ID = Convert.ToInt32(ap_id);
                        db.PicInActivity.Add(picinact);
                        db.SaveChanges();
                        return Content("<script>;alert('添加成功');history.go(-1)</script>");
                    }
                    return View();
                }
            }
            else
            {
                return Content("<script>;alert('你还没有登陆哦!');history.go(-1)</script>");
            }
          }
            else
            {
                return Content("<script>;alert('活动已经结束了哦!');history.go(-1)</script>");
            }
            return View();
        }
        #endregion

        #region 我的参与
        public ActionResult MyAtt(int ? page)
        {
            int UID = Convert.ToInt32(Session["UID"].ToString());
            var Activity = (from a in db.Activity
                            join b in db.PicInActivity on a.Ac_ID equals b.Ac_ID
                            join c in db.ActPicture.Where(c => c.UID==UID) on b.AP_ID equals c.AP_ID select a).Distinct().ToList();
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(Activity.ToPagedList(pageNumber,pageSize));
        }
        #endregion

        #region 活动结束
        public ActionResult End(int id)
        {
            Activity act = (from p in db.Activity where p.Ac_ID==id select p).FirstOrDefault();
            act.IsAct = 0;
            db.SaveChanges();
            return Content("<script>;alert('活动取消成功');history.go(-1)</script>");
        }
        #endregion

        #region 控制信息长度
        [HttpGet]
        public string strLength(string news)
        {
            int length = news.Length;
            string dotDot = "...";
            if (length >= 50)
            {
                string cutStr = news.Substring(0, 50);
                string endNews = String.Format("{0}{1}", cutStr, dotDot);
                return endNews;
            }
            else
            {
                return news;
            }
        }
        #endregion
    }
}