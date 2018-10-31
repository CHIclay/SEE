using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IActivity:IBase<Activity>
    {
        //查看全部活动
        List<Activity> List();
    }
}
