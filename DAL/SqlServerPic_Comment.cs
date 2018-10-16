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
    public class SqlServerPic_Comment:SqlServerBase<Pic_Comment>,IPic_Comment
    {
        public override Expression<Func<Pic_Comment, bool>> GetByIdKey(int id)
        {
            return u => u.PC_ID == id;
        }
        public override Expression<Func<Pic_Comment, string>> GetKey()
        {
            return u => u.PC_Mes;
        }
        SEEEntities db = new SEEEntities();
        public IEnumerable<Pic_Comment> GetPC(int picid)
        {
            var data = (from p in db.Pic_Comment
                        where p.Pic_ID == picid
                        select p).OrderBy(p => p.PC_Time);
            return data;
        }
        public void InsertPC(Pic_Comment pcmes)
        {
            db.Pic_Comment.Add(pcmes);
            db.SaveChanges();
        }
        public int Pic_CommentCount(int picid)
        {
            var data = (from p in db.Pic_Comment
                        where p.Pic_ID == picid
                        select p).Count();
            return data;
        }
        //获取全部图片评论信息
        public List<Pic_Comment> List()
        {
            var pc = (from p in db.Pic_Comment select p).ToList();
            return pc;
        }
    }
}
