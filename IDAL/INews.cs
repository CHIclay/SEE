using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface INews:IBase<News>
    {
        void InsertNews(News news);
        List<News> SelectNews(string News_Name);
        News GetNewsByID(int News_ID);
        News GetNewsByName(string News_Name);
       
        IQueryable<News> List();
    }
}
