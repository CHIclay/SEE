//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pic_Comment_Comment
    {
        public int PCC_ID { get; set; }
        public int User_ID { get; set; }
        public int PC_ID { get; set; }
        public string PCC_Mes { get; set; }
        public Nullable<System.DateTime> PCC_Time { get; set; }
    
        public virtual Pic_Comment Pic_Comment { get; set; }
        public virtual User User { get; set; }
    }
}
