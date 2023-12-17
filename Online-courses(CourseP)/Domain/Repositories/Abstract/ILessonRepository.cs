using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ILessonRepository
    {
        public IQueryable<Lesson> GetList();
        public Lesson GetByID(int id);
        public void Save(Lesson entity);
        public void Delete(int id);
        public bool IsExistLesson(int id);
    }
}
