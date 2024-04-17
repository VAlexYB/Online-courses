using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.Security.Claims;

namespace Online_courses_CourseP_.Areas.Tutor.Controllers
{
    [Area(nameof(Tutor))]
    public class HomeController : Controller
    {
        private readonly _DataManager dataManager;
        

        public HomeController(_DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IQueryable<Group> groups = dataManager.GroupRep.GetList().Where(group => group.TutorId == userId);
            ViewBag.Students = dataManager.StudentRep.GetSelectListItems();
            ViewBag.Groups = dataManager.GroupRep.GetSelectListItems();
            return View(groups);
        }

        public IActionResult GetStudentsComponent(int page, int pageSize)
        {
            return ViewComponent("Students", new { page = page, pageSize = pageSize });
        }

        public IActionResult GetLessonsComponent(int page, int pageSize)
        {
            return ViewComponent("Students", new { page = page, pageSize = pageSize });
        }
    }
}
