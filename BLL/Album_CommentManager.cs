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
        private IAlbum_Comment iac = DataAccess.CreateAlbum_Comment();
        public override IBase<Album_Comment> GetDal()
        {
            return DataAccess.CreateAlbum_Comment();
        }
        //获取全部相册评论信息
        public List<Album_Comment> List()
        {
            return iac.List();
        }
    }
}
