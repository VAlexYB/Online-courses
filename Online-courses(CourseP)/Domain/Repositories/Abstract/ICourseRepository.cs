using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ICourseRepository
    {
        public IQueryable<Course> GetList();
        public Course GetByID(int id);
        public void Save(Course entity);
        public void Delete(int id);
        public bool IsExistCourse(int id);
        public List<SelectListItem> GetSelectListItems();
    }
}
