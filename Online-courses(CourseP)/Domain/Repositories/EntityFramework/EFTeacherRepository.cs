using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFTeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext context;
        public EFTeacherRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public void Delete(string id)
        {
            context.Teachers.Remove(new Teacher { Id = id });
        }

        public Teacher GetByID(string id)
        {
            return context.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Teacher> GetList()
        {
            return context.Teachers;
        }

        public bool IsExistTeacher(string id)
        {
            return context.Teachers.Any(x => x.Id == id);
        }

        public void Save(Teacher entity)
        {
            if (!IsExistTeacher(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public IQueryable<Teacher> GetPagedTeachersAsync(int page, int pageSize)
        {
            return context.Teachers.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public int GetCount()
        {
            return context.Teachers.Count();
        }
    }
}
