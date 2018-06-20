using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL
{
    public class SqlServerNews:SqlServerBase<News>,INews
    {
        public override Expression<Func<News, bool>> GetByIdKey(int id)
        {
            return u => u.News_ID == id;
        }

        public override Expression<Func<News, string>> GetKey()
        {
            return u => u.News_ID.ToString();
        }
        SEEEntities db = new SEEEntities();
        public void InsertNews(News news)
        {
            db.News.Add(news);
            db.SaveChanges();
        }
        public List<News> SelectNews(string News_Name)
        {
            var news = (from u in db.News
                        where u.News_Name == News_Name
                        select u).ToList();
            return news;
        }
        public News GetNewsByID(int News_ID)
        {
            News news = (from u in db.News
                         where u.News_ID == News_ID
                         select u).FirstOrDefault();
            return news;
        }
        public News GetNewsByName(string News_Name)
        {
            News news = (from u in db.News
                         where u.News_Name == News_Name
                         select u).FirstOrDefault();
            return news;
        }

      
        public IQueryable<News> List()
        {
            return db.Set<News>();
        }
    }
}
