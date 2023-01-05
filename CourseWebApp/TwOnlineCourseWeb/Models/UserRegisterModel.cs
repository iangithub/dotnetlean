using Microsoft.AspNetCore.Diagnostics;
using System;
using System.ComponentModel.DataAnnotations;

namespace TwOnlineCourseWeb.Models
{
    public class UserRegisterModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "請輸入名稱")]
        [Display(Name = "名稱")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string Pwd { get; set; }
        [Required(ErrorMessage = "請再次輸入密碼")]
        [Display(Name = "再次確認密碼")]
        public string ConfirmPwd { get; set; }
        [Required(ErrorMessage = "請輸入Email做為登入帳號")]
        public string Email { get; set; }
    }

    public class UserPwdChgModel
    {
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
        public string ConfirmNewPwd { get; set; }
    }
}
