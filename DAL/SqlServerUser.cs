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
   public class SqlServerUser:SqlServerBase<User>,IUser
    {
        public override Expression<Func<User, bool>> GetByIdKey(int id)
        {
            return u => u.User_ID == id;
        }

        public override Expression<Func<User, string>> GetKey()
        {
            return u => u.User_ID.ToString();
        }
        SEEEntities db = new SEEEntities();
        //用户注册？
        public void InsertUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
        }
        
        public List<User> SelectUser(string User_Name)
        {
            var users = (from u in db.User
                        where u.User_Name == User_Name
                        select u).ToList();
            return users;
        }
        //用户登录
        public int Login(User user)
        {
            var users= from u in db.User
                       where u.User_Name == user.User_Name && u.User_Pwd == user.User_Pwd
                       select u;
            int result = users.Count();
            return result;
        }
        //AJSX登录方法？
        public int AjaxLogin(string User_Name,string User_Pwd)
        {
            var users = from u in db.User
                        where u.User_Name == User_Name && u.User_Pwd == User_Pwd
                        select u;
            return users.Count();
        }
        //通过ID获取用户
        public User GetUserByID(int User_ID)
        {
            User users = (from u in db.User
                          where u.User_ID == User_ID
                          select u).FirstOrDefault();
            return users;
        }
        //通过用户名获取用户
        public User GetUserByName(string User_Name)
        {
            User users=(from u in db.User
                        where u.User_Name==User_Name
                        select u).FirstOrDefault();
            return users;
        }
        //更新用户数据
        public void UpdateUserInfo(User user)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

    }
}
