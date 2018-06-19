using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class Pic_CommentMetaData
    {
        [Key]
        public int PC_ID { get; set; }
        //[Required(ErrorMessage ="图片评论不能为空")]
        //public string PC_Mes { get; set; }
    }
    [MetadataType(typeof(Pic_CommentMetaData))]
    public partial class Pic_Comment
    {

    }
}
