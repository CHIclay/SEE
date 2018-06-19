using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class News_CommentMetaData
    {
        [Key]
        public int NC_ID { get; set; }
        [Required(ErrorMessage ="评论内容不能为空")]
        public string NC_Mes { get; set; }
    }
}
