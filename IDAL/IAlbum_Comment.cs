using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IAlbum_Comment:IBase<Album_Comment>
    {
        //获取全部献策评论
        List<Album_Comment> List();
    }
}
