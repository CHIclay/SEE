using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
 

namespace DAL
{
    public class SqlServerPic_Comment:IPic_Comment
    {
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
    }
}
