using Microsoft.AspNetCore.Mvc;

namespace Online_courses_CourseP_.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
