using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface ITutorRepository
    {
        public IQueryable<Tutor> GetList();
        public Tutor GetByID(string id);
        public void Save(Tutor entity);
        public void Delete(string id);
        public bool IsExistTutor(string id);
    }
}
