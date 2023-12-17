using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Areas.AdminArea.Controllers;
using Online_courses_CourseP_.Domain.SchoolEntities;
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

        //public async Task<IActionResult> Edit(string id)
        //{
        //    Domain.SchoolEntities.Admin admin;
        //    if (!adminRep.IsExistAdmin(id))
        //    {
        //        admin = new Domain.SchoolEntities.Admin();
        //        await userManager.CreateAsync(admin);
        //    }
        //    else
        //    {
        //        admin = adminRep.GetByID(id);
        //    }
        //    return View(admin);
        //}

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

        public async Task<Tutor> EditTutor(string id)
        {
            Tutor tutor;
            if (dataManager.TutorRep.IsExistTutor(id))
            {
                tutor = dataManager.TutorRep.GetByID(id);
            }
            else
            {
                tutor = new Tutor();
                await userManager.CreateAsync(tutor);
            }
            return tutor;
        }
        public async Task<Teacher> EditTeacher(string id)
        {
            Teacher teacher;
            if (dataManager.TeacherRep.IsExistTeacher(id))
            {
                teacher = dataManager.TeacherRep.GetByID(id);
            }
            else
            {
                teacher = new Teacher();
                await userManager.CreateAsync(teacher);
            }
            return teacher;
        }

        public async Task<IActionResult> EditTutor(Tutor model)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (!await userManager.IsInRoleAsync(model, "tutor"))
                {
                    await userManager.AddToRoleAsync(model, "tutor");
                }
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
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        public async Task<IActionResult> EditTeacher(Teacher model)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (!await userManager.IsInRoleAsync(model, "teacher"))
                {
                    await userManager.AddToRoleAsync(model, "teacher");
                }
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
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }




        //[HttpPost]
        //public async Task<IActionResult> Delete(string id)
        //{
        //    await userManager.DeleteAsync(adminRep.GetByID(id));
        //    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        //}
    }
}
