using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Areas.Admin.Models;
using Online_courses_CourseP_.Areas.Admin;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Service;
using System.Security.Claims;
using Online_courses_CourseP_.Areas.Tutor.Models;

namespace Online_courses_CourseP_.Areas.Tutor.Controllers
{
    [Area(nameof(Tutor))]
    public class GroupController : Controller
    {
        private readonly _DataManager dataManager;

        public GroupController(_DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(int id)
        {
            
            var viewModel = new GroupViewModel
            {
                Courses = dataManager.CourseRep.GetSelectListItems()
            };
            

            var group = dataManager.GroupRep.GetByID(id);
            if (group != null)
            {
                viewModel.Id = id;
                viewModel.Beginning = group.Beginning;
                viewModel.Ending = group.Ending;
                viewModel.CourseId = group.CourseId;
                viewModel.AffiliationAgreements = group.AffiliationAgreements;
                viewModel.Lessons = group.Lessons;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(GroupViewModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                courseModel.Courses = dataManager.CourseRep.GetSelectListItems();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tutor = dataManager.TutorRep.GetByID(userId);
            var group = new Group
            {
                Id = courseModel.Id,
                Beginning = courseModel.Beginning,
                Ending = courseModel.Ending,
                CourseId = courseModel.CourseId,
                Course = dataManager.CourseRep.GetByID(courseModel.CourseId),
                AffiliationAgreements = courseModel.AffiliationAgreements,
                TutorId = tutor.Id,
                Tutor = tutor
            };
            dataManager.GroupRep.Save(group);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.GroupRep.Delete(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
