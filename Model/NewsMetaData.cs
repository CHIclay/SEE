using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class NewsMetaData
    {
        [Key]
        public int News_ID { get; set; }
        [Required(ErrorMessage ="新闻标题不能为空")]
        public string News_Name { get; set; }
        [Required(ErrorMessage ="新闻内容不能为空")]
        public string News_Mes { get; set; }
    }
    [MetadataType(typeof(NewsMetaData))]
    public partial class News
    {

    }
}
