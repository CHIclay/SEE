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
    public class News_CommentManager:BaseManager<News_Comment>
    {
        public override IBase<News_Comment> GetDal()
        {
            return DataAccess.CreateNews_Comment();
        }
        private INews_Comment inews_comment = DataAccess.CreateNews_Comment();
        public void InsertNC(News_Comment NC)
        {
            inews_comment.InsertNC(NC);
        }
        //获取全部新闻评论信息
        public List<News_Comment> List()
        {
            return inews_comment.List();
        }
    }
}
