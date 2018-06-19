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
    public class News_CommentManager
    {
        private INews_Comment inews_comment = DataAccess.CreateNews_Comment();
        public void InsertNC(News_Comment NC)
        {
            inews_comment.InsertNC(NC);
        }
    }
}
