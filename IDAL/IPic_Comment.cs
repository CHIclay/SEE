using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace IDAL
{
    public interface IPic_Comment
    {
        IEnumerable<Pic_Comment> GetPC(int picid);
        void InsertPC(Pic_Comment pcmes);
        int Pic_CommentCount(int picid);
    }
}
