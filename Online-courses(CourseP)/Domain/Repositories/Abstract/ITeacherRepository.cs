using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ITeacherRepository
    {
        public IQueryable<Teacher> GetList();
        public Teacher GetByID(string id);
        public void Save(Teacher entity);
        public void Delete(string id);
        public bool IsExistTeacher(string id);
    }
}
