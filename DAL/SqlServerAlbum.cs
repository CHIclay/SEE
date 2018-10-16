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
    public class SqlServerAlbum:SqlServerBase<Album>,IAlbum
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<Album,bool>> GetByIdKey(int id)
        {
            return u => u.Alb_ID == id;
        }
        public override Expression<Func<Album,string>> GetKey()
        {
            return u => u.Alb_Mes;
        }
        //获取全部相册信息
        public List<Album> List()
        {
            var albums = (from p in db.Album select p).ToList();
            return albums;
        }
    }
}
