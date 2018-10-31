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
    public class SqlServerActivity:SqlServerBase<Activity>,IActivity
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<Activity,bool>> GetByIdKey(int id)
        {
            return u => u.Ac_ID == id;
        }
        public override Expression<Func<Activity,string>> GetKey()
        {
            return u => u.Ac_Mes;
        }
        
        //查看全部活动
        public List<Activity> List()
        {
            var acts = (from p in db.Activity select p).ToList();
            return acts;
        }
    }
}
