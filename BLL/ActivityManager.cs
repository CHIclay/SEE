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
    public class ActivityManager:BaseManager<Activity>
    {
        private IActivity iact = DataAccess.CreateActivity();
        public override IBase<Activity> GetDal()
        {
            return DataAccess.CreateActivity();
        }

        //查看全部活动信息
        public List<Activity> List()
        {
            return iact.List();
        }
    }
}
