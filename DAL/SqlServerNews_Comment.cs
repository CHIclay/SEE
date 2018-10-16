using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using IDAL;
using System.Linq.Expressions;


namespace DAL
{
    public class SqlServerNews_Comment:SqlServerBase<News_Comment>,INews_Comment
    {
        SEEEntities db = new SEEEntities();
        public override Expression<Func<News_Comment, bool>> GetByIdKey(int id)
        {
            return u => u.News_ID == id;
        }
        public override Expression<Func<News_Comment, string>> GetKey()
        {
            return u => u.NC_Mes;
        }
        public void InsertNC(News_Comment NC)
        {
            db.News_Comment.Add(NC);
        }
        //获取全部新闻评论信息
        public List<News_Comment> List()
        {
            var ncs = (from p in db.News_Comment select p).ToList();
            return ncs;
        }
    }
}
