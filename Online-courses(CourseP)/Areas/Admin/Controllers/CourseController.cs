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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var course = dataManager.CourseRep.GetByID(id);
            var viewModel = new CourseViewModel
            {
                Categories = dataManager.CategoryRep.GetSelectListItems(),
                SkillLevels = dataManager.SkillLevelRep.GetSelectListItems()
            };
            if (course != null)
            {
                viewModel.Id = id;
                viewModel.Name = course.Name;
                viewModel.Skill = course.Skill;
                viewModel.Price = course.Price;
                viewModel.Duration = course.Duration;
                viewModel.CategoryId = course.CategoryId;
                viewModel.SkillLevelId = course.SkillLevelId;
                viewModel.Groups = course.Groups;
                viewModel.Lessons = course.Lessons;
                viewModel.ResponsibilityAgreements = course.ResponsibilityAgreements;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                courseModel.Categories = dataManager.CategoryRep.GetSelectListItems();
                courseModel.SkillLevels = dataManager.SkillLevelRep.GetSelectListItems();
            }
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var admin = dataManager.AdminRep.GetByID(userId);
            var course = new Course
            {
                Id = courseModel.Id,
                Name = courseModel.Name,
                Skill = courseModel.Skill,
                Price = courseModel.Price,
                Duration = courseModel.Duration,
                CategoryId = courseModel.CategoryId,
                Category = dataManager.CategoryRep.GetByID(courseModel.CategoryId),
                SkillLevelId = courseModel.SkillLevelId,
                SkillLevel = dataManager.SkillLevelRep.GetByID(courseModel.SkillLevelId),
                Admin = admin,
                AdminId = userId,
                Groups = courseModel.Groups,
                Lessons = courseModel.Lessons,
                ResponsibilityAgreements = courseModel.ResponsibilityAgreements
            };
            dataManager.CourseRep.Save(course);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.CourseRep.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
