using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class Album_CommentMetaData
    {
        [Key]
        public int AC_ID { get; set; }
        //[Required(ErrorMessage ="相册评论不能为空")]
        //public string AC_Mes { get; set; }
    }
    [MetadataType(typeof(Album_CommentMetaData))]
    public partial class Album_Comment
    {
         
    }
}
