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
    public class UserInfoManager:BaseManager<UserInfo>
    {
        public override IBase<UserInfo> GetDal()
        {
            return DataAccess.CreateUserInfo();
        }
        private IUserInfo iuser = DataAccess.CreateUserInfo();
        public void InsertUser(UserInfo user)
        {
            iuser.InsertUser(user);
        }
        public List<UserInfo> SelectUser(string User_Name)
        {
            return iuser.SelectUser(User_Name);
        }
        public int Login(UserInfo user)
        {
            return iuser.Login(user);
        }
        public UserInfo GetUserByID(int User_ID)
        {
            return iuser.GetUserByID(User_ID);
        }
        public UserInfo GetUserByName(string User_Name)
        {
            return iuser.GetUserByName(User_Name);
        }
        public void UpdateUserInfo(UserInfo user)
        {
            iuser.UpdateUserInfo(user);
        }
        //获取全部用户信息
        public List<UserInfo> List()
        {
            return iuser.List();
        }
    }
}
