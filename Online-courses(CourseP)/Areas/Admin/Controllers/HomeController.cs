using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Areas.AdminArea.Controllers
{
    [Area(nameof(Admin))]
    public class HomeController : Controller
    {
        private readonly ICourseRepository courseRep;
        public HomeController(ICourseRepository courseRep)
        {
            this.courseRep = courseRep;
        }
        public IActionResult Index()
        {
            return View(courseRep.GetList());
        }

        public IActionResult GetTutorsComponent(int page, int pageSize)
        {
            
            return ViewComponent("Tutors", new { page = page, pageSize = pageSize });
        }

        public IActionResult GetTeachersComponent(int page, int pageSize)
        {
            return ViewComponent("Teachers", new { page = page, pageSize = pageSize });
        }
    }
}
