using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using DALFactory;
using IDAL;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        private IUser iuser = DataAccess.CreateUser();
        public void InsertUser(User user)
        {
            iuser.InsertUser(user);
        }
        public List<User> SelectUser(string User_Name)
        {
            return iuser.SelectUser(User_Name);
        }
        public int Login(User user)
        {
            return iuser.Login(user);
        }
        public int AjaxLogin(string User_Name,string User_Pwd)
        {
            return iuser.AjaxLogin(User_Name, User_Pwd);
        }
        public User GetUserByID(int User_ID)
        {
            return iuser.GetUserByID(User_ID);
        }
        public User GetUserByName(string User_Name)
        {
            return iuser.GetUserByName(User_Name);
        }
        public void UpdateUserInfo(User user)
        {
            iuser.UpdateUserInfo(user);
        }
    }
}
