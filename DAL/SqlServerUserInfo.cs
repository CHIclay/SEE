using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
   public class SqlServerUserInfo:SqlServerBase<UserInfo>,IUserInfo
    {
        public override Expression<Func<UserInfo, bool>> GetByIdKey(int id)
        {
            return u => u.UID == id;
        }

        public override Expression<Func<UserInfo, string>> GetKey()
        {
            return u => u.UID.ToString();
        }
        SEEEntities db = new SEEEntities();
        //用户注册？
        public void InsertUser(UserInfo user)
        {
            db.UserInfo.Add(user);
            db.SaveChanges();
        }
        
        public List<UserInfo> SelectUser(string User_Name)
        {
            var users = (from u in db.UserInfo
                        where u.User_Name == User_Name
                        select u).ToList();
            return users;
        }
        //用户登录
        public int Login(UserInfo user)
        {
            var users= from u in db.UserInfo
                       where u.User_Name == user.User_Name && u.User_Pwd == user.User_Pwd
                       select u;
            int result = users.Count();
            return result;
        }
        //通过ID获取用户
        public UserInfo GetUserByID(int UID)
        {
            UserInfo users = (from u in db.UserInfo
                          where u.UID == UID
                          select u).FirstOrDefault();
            return users;
        }
        //通过用户名获取用户
        public UserInfo GetUserByName(string User_Name)
        {
            UserInfo users=(from u in db.UserInfo
                        where u.User_Name==User_Name
                        select u).FirstOrDefault();
            return users;
        }
        //更新用户数据
        public void UpdateUserInfo(UserInfo user)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        //获取全部用户信息
        public List<UserInfo> List()
        {
            var users = (from p in db.UserInfo select p).ToList().OrderByDescending(a => a.User_Time).ToList();
            return users;
        }

    }
}
