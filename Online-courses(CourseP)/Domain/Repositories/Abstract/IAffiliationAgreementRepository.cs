using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.Abstract
{
    public interface IAffiliationAgreementRepository
    {
        public int? FindBySideIds(string studentId, int groupId);
        public IQueryable<Group> GetList(string studentId);
        public IQueryable<Student> GetList(int groupId);
        public void Save(AffiliationAgreement entity);
        public void Delete(int agreementId);
        public bool IsExistAgreement(int agreementId);
    }
}
