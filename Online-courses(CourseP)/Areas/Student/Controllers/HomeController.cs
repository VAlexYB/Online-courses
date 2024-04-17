using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using System.Security.Claims;

namespace Online_courses_CourseP_.Areas.Student.Controllers
{
    [Area(nameof(Student))]
    public class HomeController : Controller
    {
        private readonly ILessonRepository lessonRep;
        public HomeController(ILessonRepository lessonRep)
        {
            this.lessonRep = lessonRep;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(lessonRep.GetListForStudentSchedule(userId));
        }
    }
}
