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
    
    public partial class Pic_Point
    {
        public int PP_ID { get; set; }
        public int UID { get; set; }
        public int Pic_ID { get; set; }
        public Nullable<System.DateTime> PP_Time { get; set; }
    
        public virtual Picture Picture { get; set; }
        public virtual UserInfo UserInfo { get; set; }
    }
}
