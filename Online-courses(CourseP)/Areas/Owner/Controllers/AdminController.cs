using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;
using Online_courses_CourseP_.Service;
using System.Threading.Tasks;

namespace Online_courses_CourseP_.Areas.Owner.Controllers
{
    [Area(nameof(Owner))]
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminRep;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IMapper mapper;

        public AdminController(IAdminRepository adminRep, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this.adminRep = adminRep;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Edit(string id)
        {
            Domain.SchoolEntities.Admin admin;
            if (!adminRep.IsExistAdmin(id))
            { 
                admin = new Domain.SchoolEntities.Admin();
                await userManager.CreateAsync(admin);
            }
            else
            {
                admin = adminRep.GetByID(id);
            }
            return View(admin);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Domain.SchoolEntities.Admin adminModel)
        {
            if (ModelState.IsValid)
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                if (!await userManager.IsInRoleAsync(adminModel, "admin"))
                {
                    await userManager.AddToRoleAsync(adminModel, "admin");
                }
                if (adminRep.IsExistAdmin(adminModel.Id))
                {
                    Domain.SchoolEntities.Admin existEntity = adminRep.GetByID(adminModel.Id);
                    mapper.Map(adminModel, existEntity);

                    existEntity.PasswordHash = passwordHasher.HashPassword(existEntity, adminModel.Password);
                    existEntity.NormalizedUserName = adminModel.UserName.ToUpper();
                    existEntity.EmailConfirmed = true;
                    existEntity.SecurityStamp = string.Empty;
                    adminRep.Save(existEntity);
                }
                else
                {
                    adminModel.PasswordHash = passwordHasher.HashPassword(adminModel, adminModel.Password);
                    adminModel.NormalizedUserName = adminModel.UserName.ToUpper();
                    adminModel.EmailConfirmed = true;
                    adminModel.SecurityStamp = string.Empty;
                    adminRep.Save(adminModel);
                }
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(adminModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await userManager.DeleteAsync(adminRep.GetByID(id));
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
