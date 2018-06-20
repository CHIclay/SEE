using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DALFactory;
using IDAL;

namespace BLL
{
    public class NewsManager:BaseManager<News>
    {
        public override IBase<News> GetDal()
        {
            return DataAccess.CreateNews();
        }
        private INews inews = DataAccess.CreateNews();
        public void InsertNews(News news)
        {
            inews.InsertNews(news);
        }
        public List<News> SelectNews(string News_Name)
        {
            return inews.SelectNews(News_Name);
        }
        public News GetNewsByID(int News_ID)
        {
            return inews.GetNewsByID(News_ID);
        }
        public News GetNewsByName(string News_Name)
        {
            return inews.GetNewsByName(News_Name);
        }
       
        public IQueryable<News> List()
        {
            return inews.List();
        }
    }
}
