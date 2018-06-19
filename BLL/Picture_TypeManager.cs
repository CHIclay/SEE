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
    public class Picture_TypeManager:BaseManager<Picture_Type>
    {
        public override IBase<Picture_Type> GetDal()
        {
            return DataAccess.CreatePicture_Type();
        }
        public Picture_Type SelectID(int id)
        {
            return DataAccess.CreatePicture_Type().SelectID(id);
        }
        public bool DeleteID(int id)
        {
            return DataAccess.CreatePicture_Type().DeleteID(id) > 0;
        }
    }
}
