using Online_courses_CourseP_.Domain.Repositories.Abstract;

namespace Online_courses_CourseP_.Areas.Admin
{
    public class DataManager
    {
        public IAdminRepository AdminRep { get; set; }

        public ICourseRepository CourseRep { get; set; }
        public ICategoryRepository CategoryRep { get; set; }
        public IResponsibilityAgreementRepository AgreementRep { get; set;}
        public ISkillLevelRepository SkillLevelRep { get; set; }
        public ITutorRepository TutorRep { get; set; }
        public ITeacherRepository TeacherRep { get; set; }
        public DataManager(IAdminRepository adminRep, ICourseRepository courseRep, ICategoryRepository categoryRep, IResponsibilityAgreementRepository respAgRep,
            ISkillLevelRepository skillLevelRep, ITutorRepository tutorRep, ITeacherRepository teacherRep) 
        {
            AdminRep = adminRep;
            CourseRep = courseRep;
            CategoryRep = categoryRep;
            AgreementRep = respAgRep;
            SkillLevelRep = skillLevelRep;
            TutorRep = tutorRep;
            TeacherRep = teacherRep;
        }
    }
}
