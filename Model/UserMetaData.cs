using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    internal class UserMetaData
    {
        [Key]
        public int User_ID { get; set; }
        //[Required(ErrorMessage ="请上传图片")]
        //public string User_Img { get; set; }
        [Required(ErrorMessage = "用户名不能为空")]
        public string User_Name { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        public string User_Pwd { get; set; }
        [Required(ErrorMessage = "请确认输入的密码")]
        [Compare("User_Pwd", ErrorMessage = "两次输入的密码不一致")]
        public string User_ConPwd { get; set; }
        [Required(ErrorMessage = "请确定性别")]
        public string User_Sex { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "请输入信箱")]
        public string User_Ema { get; set; }
        [Required(ErrorMessage = "请输入号码")]
        [Phone]
        public string User_Pho { get; set; }
    }
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
       
    }
}
