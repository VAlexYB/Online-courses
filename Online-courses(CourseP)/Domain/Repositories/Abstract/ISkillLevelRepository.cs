using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ISkillLevelRepository
    {
        public SkillLevel GetByID(int id);
        public List<SelectListItem> GetSelectListItems();
    }
}
