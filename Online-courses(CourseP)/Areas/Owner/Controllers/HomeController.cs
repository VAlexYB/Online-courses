using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;

namespace Online_courses_CourseP_.Areas.Owner.Controllers
{
    [Area(nameof(Owner))]
    public class HomeController : Controller
    {
        private readonly IAdminRepository adminRep;
        public HomeController(IAdminRepository adminRep)
        {
            this.adminRep = adminRep;
        }
        public IActionResult Index()
        {
            return View(adminRep.GetList());
        }
    }
}
