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
    public class SqlServerActPicture:SqlServerBase<ActPicture>,IActPicture
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<ActPicture, bool>> GetByIdKey(int id)
        {
            return u => u.AP_ID == id;
        }
        public override Expression<Func<ActPicture, string>> GetKey()
        {
            return u => u.AP_Mes;
        }

        //查看全部活动
        public List<ActPicture> List()
        {
            var acts = (from p in db.ActPicture select p).ToList();
            return acts;
        }
    }
}
