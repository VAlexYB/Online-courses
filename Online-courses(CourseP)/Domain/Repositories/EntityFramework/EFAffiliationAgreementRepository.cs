using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFAffiliationAgreementRepository : IAffiliationAgreementRepository
    {
        private readonly SchoolDbContext context;
        public EFAffiliationAgreementRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(int agreementId)
        {
            AffiliationAgreement agreement = context.AffiliationAgreements.Find(agreementId);
            if (agreement != null)
            {
                context.AffiliationAgreements.Remove(agreement);
                context.SaveChanges();
            }
        }

        public int? FindBySideIds(string studentId, int groupId)
        {
            return context.AffiliationAgreements.FirstOrDefault(aa => aa.StudentId == studentId && aa.GroupId == groupId)?.Id;
        }

        public IQueryable<Group> GetList(string studentId)
        {
            return context.AffiliationAgreements.Where(aa => aa.StudentId == studentId).Select(aa => aa.Group);
        }

        public IQueryable<Student> GetList(int groupId)
        {
            return context.AffiliationAgreements.Where(aa => aa.GroupId == groupId).Select(aa => aa.Student);
        }

        public bool IsExistAgreement(int agreementId)
        {
            return context.AffiliationAgreements.Any(x => x.Id == agreementId);
        }

        public void Save(AffiliationAgreement entity)
        {
            if (!IsExistAgreement(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
