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
        public override Expression<Func<Album_Comment,bool>> GetByIdKey(int id)
        {
            return u => u.AC_ID == id;
        }
        public override Expression<Func<Album_Comment,string>> GetKey()
        {
            return u => u.AC_Mes;
        }
    }
}
