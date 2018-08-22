using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IUserInfo:IBase<UserInfo>
    {
        void InsertUser(UserInfo user);
        List<UserInfo> SelectUser(string User_Name);
        int Login(UserInfo user);
        UserInfo GetUserByID(int UID);
        UserInfo GetUserByName(string User_Name);
        void UpdateUserInfo(UserInfo user);
        //获取全部用户
        List<UserInfo> List();
    }
}
