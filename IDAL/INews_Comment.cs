﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface INews_Comment:IBase<News_Comment>
    {
        void InsertNC(News_Comment NC);
    }
}
