using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Linq.Expressions;

namespace DAL
{
    public class SqlServerAlbum_Comment:SqlServerBase<Album_Comment>,IAlbum_Comment
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<Album_Comment,bool>> GetByIdKey(int id)
        {
            return u => u.AC_ID == id;
        }
        public override Expression<Func<Album_Comment,string>> GetKey()
        {
            return u => u.AC_Mes;
        }
        //获取全部相册评论信息
        public List<Album_Comment> List()
        {
            var ac = (from p in db.Album_Comment select p).ToList();
            return ac;
        }
    }
}
