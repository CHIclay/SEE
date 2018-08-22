using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    public class SqlServerPicture_Type:SqlServerBase<Picture_Type>,IPicture_Type
    {
        public override Expression<Func<Picture_Type,bool>> GetByIdKey(int id)
        {
            return u => u.TID == id;
        }

        public override Expression<Func<Picture_Type,string>> GetKey()
        {
            return u => u.TID.ToString();
        }
        SEEEntities db = new SEEEntities();
        public Picture_Type SelectID(int id)
        {
            return db.Set<Picture_Type>().Where(u => u.TID == id).FirstOrDefault();
        }
        public int DeleteID(int id)
        {
            Picture_Type model = db.Set<Picture_Type>().Where(u => u.TID == id).FirstOrDefault();
            db.Set<Picture_Type>().Remove(model);
            return db.SaveChanges();
        }
    }
}
