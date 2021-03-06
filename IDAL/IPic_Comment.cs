﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace IDAL
{
    public interface IPic_Comment:IBase<Pic_Comment>
    {
        IEnumerable<Pic_Comment> GetPC(int picid);
        void InsertPC(Pic_Comment pcmes);
        int Pic_CommentCount(int picid);
        //获取全部图片评论
        List<Pic_Comment> List();
    }
}
