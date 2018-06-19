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
    }
}
