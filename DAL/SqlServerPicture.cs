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
    public class SqlServerPicture:SqlServerBase<Picture>,IPicture
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<Picture,bool>> GetByIdKey(int id)
        {
            return u => u.Pic_ID == id;
        }
        public override Expression<Func<Picture,string>> GetKey()
        {
            return u => u.Pic_Mes;
        }
        //获取全部图片信息
        public List<Picture> List()
        {
            var pic = (from p in db.Picture select p).OrderByDescending(a => a.Pic_Time).ToList();
            return pic;
        }
    }
}
