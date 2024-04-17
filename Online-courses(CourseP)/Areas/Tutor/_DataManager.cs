using Online_courses_CourseP_.Domain.Repositories.Abstract;

namespace Online_courses_CourseP_.Areas.Tutor
{
    public class _DataManager
    {
        public IGroupRepository GroupRep { get; set; }
        public ICourseRepository CourseRep { get; set; }
        public IAffiliationAgreementRepository AgreementRep { get; set;}
        public ITutorRepository TutorRep { get; set; }
        public ITeacherRepository TeacherRep { get; set; }
        public IStudentRepository StudentRep { get; set; }
        public ILessonRepository LessonRep { get; set; }
        public ILessonTypeRepository LessonTypeRep { get; set; }
        public _DataManager(IGroupRepository groupRep, ICourseRepository courseRep, IAffiliationAgreementRepository affilAgRep,
            ITutorRepository tutorRep, ITeacherRepository teacherRep, IStudentRepository studentRep, ILessonRepository lessonRep, ILessonTypeRepository lessonTypeRep) 
        {
            GroupRep = groupRep;
            CourseRep = courseRep;
            AgreementRep = affilAgRep;
            TutorRep = tutorRep;
            TeacherRep = teacherRep;
            StudentRep = studentRep;
            LessonRep = lessonRep;
            LessonTypeRep = lessonTypeRep;
        }
    }
}
