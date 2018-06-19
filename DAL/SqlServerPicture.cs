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
        public override Expression<Func<Picture,bool>> GetByIdKey(int id)
        {
            return u => u.Pic_ID == id;
        }
        public override Expression<Func<Picture,string>> GetKey()
        {
            return u => u.Pic_Mes;
        }
    }
}
