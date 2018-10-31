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
    public class ActPictureManager:BaseManager<ActPicture>
    {
        private IActPicture iact = DataAccess.CreateActPicture();
        public override IBase<ActPicture> GetDal()
        {
            return DataAccess.CreateActPicture();
        }

        //查看全部活动图片
        public List<ActPicture> List()
        {
            return iact.List();
        }
    }
}
