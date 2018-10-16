using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using System.Reflection;
using System.Configuration;

namespace DALFactory
{
    public class DataAccess
    {
        private static string assemblyName = ConfigurationManager.AppSettings["Path"].ToString();
        private static string db = ConfigurationManager.AppSettings["DB"].ToString();

        public static IUserInfo CreateUserInfo()
        {
            string className = assemblyName + "." + db + "UserInfo";
            return (IUserInfo)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IManager CreateManager()
        {
            string className = assemblyName + "." + db + "Manager";
            return (IManager)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static INews CreateNews()
        {
            string className = assemblyName + "." + db + "News";
            return (INews)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static INews_Comment CreateNews_Comment()
        {
            string className = assemblyName + "." + db + "News_Comment";
            return (INews_Comment)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IPicture_Type CreatePicture_Type()
        {
            string className = assemblyName + "." + db + "Picture_Type";
            return (IPicture_Type)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IPicture CreatePicture()
        {
            string className = assemblyName + "." + db + "Picture";
            return (IPicture)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IPic_Comment CreatePic_Comment()
        {
            string className = assemblyName + "." + db + "Pic_Comment";
            return (IPic_Comment)Assembly.Load(assemblyName).CreateInstance(className);
        }

        public static IAlbum CreateAlbum()
        {
            string className = assemblyName + "." + db + "Album";
            return (IAlbum)Assembly.Load(assemblyName).CreateInstance(className);

        }

        public static IAlbum_Comment CreateAlbum_Comment()
        {
            string className = assemblyName + "." + db + "Album_Comment";
            return (IAlbum_Comment)Assembly.Load(assemblyName).CreateInstance(className);

        }

    }
}
