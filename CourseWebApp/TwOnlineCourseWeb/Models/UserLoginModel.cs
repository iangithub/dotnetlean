using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TwOnlineCourseWeb.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "請輸入Email做為登入帳號")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string Pwd { get; set; }
    }
}
