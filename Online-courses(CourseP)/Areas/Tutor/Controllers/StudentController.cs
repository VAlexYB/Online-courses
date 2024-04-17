using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Areas.Admin;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Service;

namespace Online_courses_CourseP_.Areas.Tutor.Controllers
{
    [Area(nameof(Tutor))]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRep;
        private readonly IGroupRepository groupRep;
        private readonly IAffiliationAgreementRepository agreementRep;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository studentRep, IGroupRepository groupRep, IAffiliationAgreementRepository agreementRep, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.studentRep = studentRep;
            this.groupRep = groupRep;
            this.agreementRep = agreementRep;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Edit(string id)
        {
            Domain.SchoolEntities.Student student;
            if (!studentRep.IsExistStudent(id))
            {
                student = new Domain.SchoolEntities.Student();
                await userManager.CreateAsync(student);
            }
            else
            {
                student = studentRep.GetByID(id);
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Domain.SchoolEntities.Student studentModel)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (studentRep.IsExistStudent(studentModel.Id))
                {
                    Domain.SchoolEntities.Student existEntity = studentRep.GetByID(studentModel.Id);
                    mapper.Map(studentModel, existEntity);

                    existEntity.PasswordHash = passwordHasher.HashPassword(existEntity, studentModel.Password);
                    existEntity.NormalizedUserName = studentModel.UserName.ToUpper();
                    existEntity.EmailConfirmed = true;
                    existEntity.SecurityStamp = string.Empty;
                    studentRep.Save(existEntity);
                }
                else
                {
                    studentModel.PasswordHash = passwordHasher.HashPassword(studentModel, studentModel.Password);
                    studentModel.NormalizedUserName = studentModel.UserName.ToUpper();
                    studentModel.EmailConfirmed = true;
                    studentModel.SecurityStamp = string.Empty;
                    studentRep.Save(studentModel);
                }
                if (!await userManager.IsInRoleAsync(studentModel, "student"))
                {
                    await userManager.AddToRoleAsync(studentModel, "student");
                }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(studentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await userManager.DeleteAsync(studentRep.GetByID(id));
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

        [HttpPost]
        public IActionResult AddStudentToGroup(string studentId, int groupId)
        {
            Domain.SchoolEntities.Student student = studentRep.GetByID(studentId);
            Group group = groupRep.GetByID(groupId);
            if (student != null && group != null)
            {
                studentRep.AddToAffiliation(student, group);
                TempData["SuccesMessage"] = "Преподаватель успешно добавлен к курсу";
            }
            else
                TempData["ErrorMessage"] = "Не удалось найти указанного преподавателя или курс.";
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }


        [HttpPost]
        public IActionResult RemoveStudentFromGroup(string studentId, int groupId)
        {

            int? agrId = agreementRep.FindBySideIds(studentId, groupId);
            if (agrId.HasValue)
            {
                agreementRep.Delete((int)agrId);
            }
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
