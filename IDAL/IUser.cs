using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IUser:IBase<User>
    {
        void InsertUser(User user);
        List<User> SelectUser(string User_Name);
        int Login(User user);
        int AjaxLogin(string User_Name, string User_Pwd);
        User GetUserByID(int User_ID);
        User GetUserByName(string User_Name);
        void UpdateUserInfo(User user);
         
        

    }
}
