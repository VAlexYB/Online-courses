using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface IResponsibilityAgreementRepository
    {
        public IQueryable<Course> GetList(string teacherId);
        public IQueryable<Teacher> GetList(int courseId);
        public void Save(ResponsibilityAgreement entity);
        public void Delete(int agreementId);
        public bool IsExistAgreement(int agreementId);
    }
}
