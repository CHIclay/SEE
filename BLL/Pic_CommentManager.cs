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
    public class Pic_CommentManager:BaseManager<Pic_Comment>
    {
        public override IBase<Pic_Comment> GetDal()
        {
            return DataAccess.CreatePic_Comment();
        }
        public IPic_Comment ipic_comment = DataAccess.CreatePic_Comment();
        public IEnumerable<Pic_Comment> GetPC(int picid)
        {
            return ipic_comment.GetPC(picid);
        }
        public void InsertPC(Pic_Comment pcmes)
        {
            ipic_comment.InsertPC(pcmes);
        }
        public int Pic_CommentCount(int picid)
        {
            return ipic_comment.Pic_CommentCount(picid);
        }
        //获取全部图片评论信息
        public List<Pic_Comment> List()
        {
            return ipic_comment.List();
        }
    }
}
