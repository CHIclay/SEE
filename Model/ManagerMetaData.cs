using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class ManagerMetaData
    {
        [Key]
        public int Man_ID { get; set; }
        [Required(ErrorMessage ="管理员名不能为空")]
        public string Man_Name { get; set; }
        [Required(ErrorMessage ="管理员密码不能为空")]
        public string Man_Pas { get; set; }
    }[MetadataType(typeof(ManagerMetaData))]
    public partial class Manager
    {

    }
}
