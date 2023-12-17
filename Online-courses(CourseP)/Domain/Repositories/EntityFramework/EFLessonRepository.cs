using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFLessonRepository : ILessonRepository
    {
        private readonly SchoolDbContext context;
        public EFLessonRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Lessons.Remove(new Lesson { Id = id });
        }

        public Lesson GetByID(int id)
        {
            return context.Lessons.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Lesson> GetList()
        {
            return context.Lessons;
        }

        public bool IsExistLesson(int id)
        {
            return context.Lessons.Any(x => x.Id == id);
        }

        public void Save(Lesson entity)
        {
            if (!IsExistLesson(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
