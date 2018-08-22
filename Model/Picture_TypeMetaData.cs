using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Model
{
    internal class Picture_TypeMetaData
    {
        [Key]
        public int TID { get; set; }
        [Required(ErrorMessage ="类型名称不能为空")]
        public string Name { get; set; }
    }
    [MetadataType(typeof(Picture_TypeMetaData))]
    public partial class Picture_Type
    {

    }
}
