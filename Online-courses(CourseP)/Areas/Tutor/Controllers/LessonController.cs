using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Areas.Admin.Models;
using Online_courses_CourseP_.Areas.Admin;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Service;
using System.Security.Claims;
using Online_courses_CourseP_.Areas.Tutor.Models;
using System.Data;

namespace Online_courses_CourseP_.Areas.Tutor.Controllers
{
    [Area(nameof(Tutor))]
    public class LessonController : Controller
    {
        private readonly _DataManager dataManager;

        public LessonController(_DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(int id)
        {
            var lesson = dataManager.LessonRep.GetByID(id);
            var viewModel = new LessonViewModel
            {
                LessonTypes = dataManager.LessonTypeRep.GetSelectListItems(),
                Courses = dataManager.CourseRep.GetSelectListItems(),
                Groups = dataManager.GroupRep.GetSelectListItems(),
                Teachers = dataManager.TeacherRep.GetSelectListItems()
            };
            if (lesson != null)
            {
                viewModel.Id = id;
                viewModel.Beginning = lesson.Beginning;
                viewModel.Duration = lesson.Duration;
                viewModel.CourseId = lesson.CourseId;
                viewModel.TeacherId = lesson.TeacherId;
                viewModel.GroupId = lesson.GroupId;
                viewModel.LessonTypeId = lesson.LessonTypeId;
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(LessonViewModel lessonModel)
        {
            if (!ModelState.IsValid)
            {
                lessonModel.LessonTypes = dataManager.LessonTypeRep.GetSelectListItems();
                lessonModel.Courses = dataManager.CourseRep.GetSelectListItems();
                lessonModel.Groups = dataManager.GroupRep.GetSelectListItems();
                lessonModel.Teachers = dataManager.TeacherRep.GetSelectListItems();
            }

            var lesson = new Lesson
            {
                Id = lessonModel.Id,
                Beginning = lessonModel.Beginning,
                Duration = lessonModel.Duration,
                CourseId = lessonModel.CourseId,
                Course = dataManager.CourseRep.GetByID(lessonModel.CourseId),
                GroupId = lessonModel.GroupId,
                Group = dataManager.GroupRep.GetByID(lessonModel.GroupId),
                TeacherId = lessonModel.TeacherId,
                Teacher = dataManager.TeacherRep.GetByID(lessonModel.TeacherId),
                LessonTypeId = lessonModel.LessonTypeId,
                LessonType = dataManager.LessonTypeRep.GetByID(lessonModel.LessonTypeId)
            };
            dataManager.LessonRep.Save(lesson);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
