using CoreLib.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using TwOnlineCourseWeb.Models;
using CoreLib.Models;

namespace TwOnlineCourseWeb.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberService;
        private ILoginService _loginService;

        public MemberController(IMemberService memberService, ILoginService loginService)
        {
            _memberService = memberService;
            _loginService = loginService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult ChangePwd()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MemberChangePwd(UserPwdChgModel userPwdChgModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (userPwdChgModel.NewPwd != userPwdChgModel.ConfirmNewPwd)
            {
                ViewBag.Info = "密碼不一致";
                return View("ChangePwd");
            }

            var result = await _memberService.MemberPwdUpdateAsync(new StudentPwdReqModel()
            {
                Id = Guid.Parse(userId),
                OldPwd = userPwdChgModel.OldPwd,
                NewPwd = userPwdChgModel.NewPwd
            });

            if (!result)
            {
                ViewBag.Info = "密碼變更失敗(原密碼錯誤或帳號不存在)";
                return View("ChangePwd");
            }

            return RedirectToAction("Logout", "Login");
        }
    }
}
