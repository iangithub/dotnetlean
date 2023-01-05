using CoreLib.Interface;
using CoreLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TwOnlineCourseWeb.Models;

namespace TwOnlineCourseWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseScheduleService _courseScheduleService;

        public HomeController(ILogger<HomeController> logger, ICourseScheduleService courseScheduleService)
        {
            _logger = logger;
            _courseScheduleService = courseScheduleService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _courseScheduleService.QueryAsync(null);
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CourseScheduleQuery(string courseName, string teacherName)
        {
           // var courseData = new List<CourseScheduleViewModel>();

            var queryResult = await _courseScheduleService.QueryAsync(new CourseScheduleQueryCondition() { CourseName = courseName, TeacherName = teacherName });
           
            ViewBag.CourseName = courseName;
            ViewBag.TeacherName = teacherName;

            return View("index", queryResult);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
