using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IDAL;
using DALFactory;

namespace BLL
{
    public class Album_CommentManager:BaseManager<Album_Comment>
    {
        public override IBase<Album_Comment> GetDal()
        {
            return DataAccess.CreateAlbum_Comment();
        }
    }
}
