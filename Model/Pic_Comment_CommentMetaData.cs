using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class Pic_Comment_CommentMetaData
    {
        [Key]
        public int PCC_ID { get; set; }
        //[Required(ErrorMessage ="评论回复不能为空")]
        //public string PCC_Mes { get; set; }
    }
    [MetadataType(typeof(Pic_Comment_CommentMetaData))]
    public partial class Pic_Comment_Comment
    {

    }
}
