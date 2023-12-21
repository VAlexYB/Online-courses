using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFCourseRepository : ICourseRepository
    {
        private readonly SchoolDbContext context;
        public EFCourseRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Course> GetList()
        {
            return context.Courses;
        }
        public Course GetByID(int id)
        {
            return context.Courses.FirstOrDefault(course => course.Id == id);
        }

        public void Save(Course entity)
        {
            if (!IsExistCourse(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Courses.Remove(new Course { Id = id });
            context.SaveChanges();
        }

        public bool IsExistCourse(int id)
        {
            return context.Courses.Any(course => course.Id == id);
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return context.Courses.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = $"{c.Name} {c.SkillLevel.SkillLevel1}" }).ToList();
        }
    }
}
