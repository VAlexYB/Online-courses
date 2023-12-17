using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFSkillLevelRepository : ISkillLevelRepository
    {
        private readonly SchoolDbContext context;
        public EFSkillLevelRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public SkillLevel GetByID(int id)
        {
            return context.SkillLevels.FirstOrDefault(x => x.Id == id);
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return context.SkillLevels.Select(sl => new SelectListItem { Value = sl.Id.ToString(), Text = sl.SkillLevel1 }).ToList();
        }
    }
}
