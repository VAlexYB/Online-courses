using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext context;
        public EFStudentRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(string id)
        {
            context.Students.Remove(new Student { Id = id });
        }

        public Student GetByID(string id)
        {
            return context.Students.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Student> GetList()
        {
            return context.Students;
        }

        public bool IsExistStudent(string id)
        {
            return context.Students.Any(x => x.Id == id);
        }

        public void Save(Student entity)
        {
            if (!IsExistStudent(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
