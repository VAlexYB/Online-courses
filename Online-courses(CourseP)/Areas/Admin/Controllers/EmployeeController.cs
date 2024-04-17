using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NuGet.DependencyResolver;
using Online_courses_CourseP_.Areas.AdminArea.Controllers;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Models;
using Online_courses_CourseP_.Service;
using System.Drawing;

namespace Online_courses_CourseP_.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class EmployeeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public EmployeeController(DataManager dataManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> EditEmployee(string role, string id)
        {
            if (role == "Tutor")
            {
                return View("EditTutor", await EditTutor(id));
            }
            else if (role == "Teacher")
            {
                return View ("EditTeacher", await EditTeacher(id));
            }
            else
                throw new Exception("Админ не умеет добавлять работников кроме тьютора и учителя. Где-то ты ошибся, товарищ");
        }

        public async Task<Domain.SchoolEntities.Tutor> EditTutor(string id)
        {
            Domain.SchoolEntities.Tutor tutor;
            if (dataManager.TutorRep.IsExistTutor(id))
            {
                tutor = dataManager.TutorRep.GetByID(id);
            }
            else
            {
                tutor = new Domain.SchoolEntities.Tutor();
                await userManager.CreateAsync(tutor);
            }
            return tutor;
        }
        public async Task<Domain.SchoolEntities.Teacher> EditTeacher(string id)
        {
            Domain.SchoolEntities.Teacher teacher;
            if (dataManager.TeacherRep.IsExistTeacher(id))
            {
                teacher = dataManager.TeacherRep.GetByID(id);
            }
            else
            {
                teacher = new Domain.SchoolEntities.Teacher();
                await userManager.CreateAsync(teacher);
            }
            return teacher;
        }
        [HttpPost]
        public async Task<IActionResult> EditTutor(Domain.SchoolEntities.Tutor model)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (dataManager.TutorRep.IsExistTutor(model.Id))
                {
                    Domain.SchoolEntities.Tutor existEntity = dataManager.TutorRep.GetByID(model.Id);
                    mapper.Map(model, existEntity);

                    existEntity.PasswordHash = passwordHasher.HashPassword(existEntity, model.Password);
                    existEntity.NormalizedUserName = model.UserName.ToUpper();
                    existEntity.EmailConfirmed = true;
                    existEntity.SecurityStamp = string.Empty;
                    dataManager.TutorRep.Save(existEntity);
                }
                else
                {
                    model.PasswordHash = passwordHasher.HashPassword(model, model.Password);
                    model.NormalizedUserName = model.UserName.ToUpper();
                    model.EmailConfirmed = true;
                    model.SecurityStamp = string.Empty;
                    dataManager.TutorRep.Save(model);
                }
                if (!await userManager.IsInRoleAsync(model, "tutor"))
                {
                    await userManager.AddToRoleAsync(model, "tutor");
                }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditTeacher(Domain.SchoolEntities.Teacher model)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (dataManager.TeacherRep.IsExistTeacher(model.Id))
                {
                    Domain.SchoolEntities.Teacher existEntity = dataManager.TeacherRep.GetByID(model.Id);
                    mapper.Map(model, existEntity);

                    existEntity.PasswordHash = passwordHasher.HashPassword(existEntity, model.Password);
                    existEntity.NormalizedUserName = model.UserName.ToUpper();
                    existEntity.EmailConfirmed = true;
                    existEntity.SecurityStamp = string.Empty;
                    dataManager.TeacherRep.Save(existEntity);
                }
                else
                {
                    model.PasswordHash = passwordHasher.HashPassword(model, model.Password);
                    model.NormalizedUserName = model.UserName.ToUpper();
                    model.EmailConfirmed = true;
                    model.SecurityStamp = string.Empty;
                    dataManager.TeacherRep.Save(model);
                }
                if (!await userManager.IsInRoleAsync(model, "teacher"))
                {
                    await userManager.AddToRoleAsync(model, "teacher");
                }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string role, string id)
        {
            if (role == "Tutor")
            {
                await userManager.DeleteAsync(dataManager.TutorRep.GetByID(id));
            }
            else if (role == "Teacher")
            {
                await userManager.DeleteAsync(dataManager.TeacherRep.GetByID(id));
            }
            else
                throw new Exception("Админ не умеет удалять работников кроме тьютора и учителя. Где-то ты ошибся, товарищ");
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        [HttpPost]
        public IActionResult AddTeacherToCourse(string teacherId, int courseId)
        {
            Domain.SchoolEntities.Teacher teacher = dataManager.TeacherRep.GetByID(teacherId);
            Course course = dataManager.CourseRep.GetByID(courseId);
            if (teacher != null && course != null)
            {
                dataManager.TeacherRep.AddToResponse(teacher, course);
                TempData["SuccesMessage"] = "Преподаватель успешно добавлен к курсу";
            }
            else
                TempData["ErrorMessage"] = "Не удалось найти указанного преподавателя или курс.";
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        [HttpPost]
        public IActionResult RemoveTeacherFromCourse(string teacherId, int courseId) 
        {
            
            int? agrId = dataManager.AgreementRep.FindBySideIds(teacherId, courseId);
            if (agrId.HasValue)
            {
                dataManager.AgreementRep.Delete((int)agrId);
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
