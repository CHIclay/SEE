using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;


namespace DAL
{
    public class SqlServerNews_Comment
    {
        SEEEntities db = new SEEEntities();
        public void InsertNC(News_Comment NC)
        {
            db.News_Comment.Add(NC);
        }
    }
}
