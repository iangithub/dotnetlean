using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using CoreLib.Interface;

namespace TwOnlineCourseWeb.Controllers
{
    public class ShopController : Controller
    {
        private IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var bookingList = await _shopService.BookingListAsync(Guid.Parse(userId));

            return View(bookingList);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ShopCar(string scheduleid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _shopService.BookingCourseAsync(Guid.Parse(userId), Guid.Parse(scheduleid));

            if (!result)
            {
                TempData["ShopCar"] = "購課失敗(請至我的課程清單檢查是否重覆購課)";
                return RedirectToAction("index", "home");
            }

            TempData["ShopCar"] = "購課成功";
            return RedirectToAction("index", "home");
        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DelBooking(string scheduleid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _shopService.BookingDeleteAsync(Guid.Parse(scheduleid));

            return RedirectToAction("index");
        }
    }
}
