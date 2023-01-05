using CoreLib.Interface;
using CoreLib.Models;
using CoreLib.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using TwOnlineCourseWeb.Models;

namespace TwOnlineCourseWeb.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var stu = await _loginService.UserSignAsync(userLoginModel.Email, userLoginModel.Pwd);

                if (stu == null)
                {
                    ViewBag.Msg = "登入失敗";
                    return View("Index", userLoginModel);
                }

                //Claim[] claims = new[] { new Claim("Account", stu.UserName) }; //自訂Claim
                Claim[] claims = new[] {
                    new Claim(ClaimTypes.Name, stu.UserName)
                    , new Claim(ClaimTypes.NameIdentifier, stu.Id.ToString())
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                //執行登入
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));

                return RedirectToAction("Index", "Home");
            }
           
            return View("Index", userLoginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            if (ModelState.IsValid)
            {
                if (userRegisterModel.Pwd != userRegisterModel.ConfirmPwd)
                {
                    //二次密碼不符
                    ViewBag.Message = "二次密碼不相符";
                    return View("UserRegister", userRegisterModel);
                }

                var user = new Student()
                {
                    UserName = userRegisterModel.UserName,
                    Pwd = userRegisterModel.Pwd,
                    Email = userRegisterModel.Email,
                };

                await _loginService.UserRegisterAsync(user);

                return View("Index");

            }

            return View("UserRegister", userRegisterModel);
        }

    }
}
