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
    
    public partial class PicInActivity
    {
        public int PIAC_ID { get; set; }
        public int Ac_ID { get; set; }
        public int AP_ID { get; set; }
        public int Num { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual ActPicture ActPicture { get; set; }
    }
}