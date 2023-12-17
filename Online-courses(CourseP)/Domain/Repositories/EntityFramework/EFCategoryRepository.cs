using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly SchoolDbContext context;
        public EFCategoryRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public Category GetByID(int id)
        {
            return context.Categories.FirstOrDefault(entity => entity.Id == id);
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return context.Categories.Select(c=> new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }
    }
}
