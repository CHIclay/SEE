using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class AlbumMetaData
    {
        [Key]
        public int Alb_ID { get; set; }
        [Required(ErrorMessage ="相册描述不能为空")]
        public string Alb_Mes { get; set; }
    }
    [MetadataType(typeof(AlbumMetaData))]
    public partial class Album
    {

    }
}
