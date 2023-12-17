using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFResponsibilityAgreementRepository : IResponsibilityAgreementRepository
    {
        private readonly SchoolDbContext context;
        public EFResponsibilityAgreementRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public void Delete(int agreementId)
        {
            context.ResponsibilityAgreements.Remove(new ResponsibilityAgreement { Id = agreementId });
        }


        public IQueryable<Course> GetList(string teacherId)
        {
            return context.ResponsibilityAgreements.Where(ra => ra.TeacherId == teacherId).Select(ra => ra.Course);
        }

        public IQueryable<Teacher> GetList(int courseId)
        {
            return context.ResponsibilityAgreements.Where(ra => ra.CourseId == courseId).Select(ra => ra.Teacher);
        }

        public bool IsExistAgreement(int agreementId)
        {
            return context.ResponsibilityAgreements.Any(x => x.Id == agreementId);
        }

        public void Save(ResponsibilityAgreement entity)
        {
            if (!IsExistAgreement(entity.Id))
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
