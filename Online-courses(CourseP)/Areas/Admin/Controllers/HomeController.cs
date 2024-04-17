using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.Security.Claims;

namespace Online_courses_CourseP_.Areas.AdminArea.Controllers
{
    [Area(nameof(Admin))]
    public class HomeController : Controller
    {
        private readonly ICourseRepository courseRep;
        private readonly ITeacherRepository teacherRep;

        public HomeController(ICourseRepository courseRep, ITeacherRepository teacherRep)
        {
            this.courseRep = courseRep;
            this.teacherRep = teacherRep;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<Course> courses = courseRep.GetList().Where(course => course.AdminId == userId);
            ViewBag.Teachers = teacherRep.GetSelectListItems();
            ViewBag.Courses = courseRep.GetSelectListItems();
            return View(courses);
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
