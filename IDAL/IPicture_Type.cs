using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IPicture_Type : IBase<Picture_Type>
    {
        Picture_Type SelectID(int id);
        int DeleteID(int id);
    }
}
