using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        public Category GetByID(int id);
        public List<SelectListItem> GetSelectListItems();
    }
}
