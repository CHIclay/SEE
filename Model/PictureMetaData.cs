using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class PictureMetaData
    {
        [Key]
        public int Pic_ID { get; set; }
        [Required(ErrorMessage ="图片描述不能为空")]
        public string Pic_Mes { get; set; }

        public virtual Picture_Type Picture_Type { get; set; }
      
    }
    [MetadataType(typeof(PictureMetaData))]
    public partial class Picture
    {

    }
}
