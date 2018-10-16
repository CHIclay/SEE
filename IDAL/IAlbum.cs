using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IAlbum:IBase<Album>
    {
        //查看全部相册
        List<Album> List();
    }
}
