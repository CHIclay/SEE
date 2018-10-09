using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using Model;
using IDAL;

namespace BLL
{
    public class PictureManager : BaseManager<Picture>
    {
        public override IBase<Picture> GetDal()
        {
            return DataAccess.CreatePicture();
        }
        private IPicture ipicture = DataAccess.CreatePicture();
        //获取全部图片信息
        public List<Picture> List()
        {
            return ipicture.List();
        }
    }
}
