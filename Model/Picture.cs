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
    
    public partial class Picture
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Picture()
        {
            this.Pic_Comment = new HashSet<Pic_Comment>();
            this.Pic_Point = new HashSet<Pic_Point>();
            this.Picture_In_Album = new HashSet<Picture_In_Album>();
        }
    
        public int Pic_ID { get; set; }
        public int User_ID { get; set; }
        public string Pic_Pic { get; set; }
        public int Type_ID { get; set; }
        public string Pic_Mes { get; set; }
        public Nullable<System.DateTime> Pic_Time { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pic_Comment> Pic_Comment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pic_Point> Pic_Point { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Picture_In_Album> Picture_In_Album { get; set; }
        public virtual Picture Picture1 { get; set; }
        public virtual Picture Picture2 { get; set; }
        public virtual Picture_Type Picture_Type { get; set; }
        public virtual User User { get; set; }
    }
}
