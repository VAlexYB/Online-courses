using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Areas.AdminArea.Controllers;
using Online_courses_CourseP_.Domain;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Areas.Admin.Models;
using Online_courses_CourseP_.Service;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Online_courses_CourseP_.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class CourseController : Controller
    {
        private readonly DataManager dataManager;

        public CourseController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(int id)
        {
            var viewModel = new CourseViewModel
            {
                Categories = dataManager.CategoryRep.GetSelectListItems(),
                SkillLevels = dataManager.SkillLevelRep.GetSelectListItems()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel courseModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var admin = dataManager.AdminRep.GetByID(userId);
                var course = new Course
                {
                    Name = courseModel.Name,
                    Skill = courseModel.Skill,
                    Price = courseModel.Price,
                    Duration = courseModel.Duration,
                    CategoryId = courseModel.CategoryId,
                    Category = dataManager.CategoryRep.GetByID(courseModel.CategoryId),
                    SkillLevelId = courseModel.SkillLevelId,
                    SkillLevel = dataManager.SkillLevelRep.GetByID(courseModel.SkillLevelId),
                    Admin = admin,
                    AdminId = userId
                };
                dataManager.CourseRep.Save(course);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(courseModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.CourseRep.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
