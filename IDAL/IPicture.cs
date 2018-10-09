using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IPicture:IBase<Picture>
    {
        //获取全部图片
        List<Picture> List();
    }
}
