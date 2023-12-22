using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
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
            context.SaveChanges();
        }

        public Lesson GetByID(int id)
        {
            return context.Lessons.FirstOrDefault(x => x.Id == id);
        }

        public int GetCount()
        {
            return context.Lessons.Count();
        }

        public IQueryable<Lesson> GetList()
        {
            return context.Lessons.Include(l => l.Course).Include(l => l.Teacher).Include(l => l.LessonType);
        }

        public IQueryable<Lesson> GetListForTeacherShedule(string teacherId)
        {
            DateTime todayMidnight = DateTime.Today; 
            return context.Lessons
                .Include(l => l.Course)
                .Include(l => l.Teacher)
                .Include(l => l.LessonType)
                .Where(lesson => lesson.Beginning > todayMidnight && lesson.TeacherId == teacherId);
        }

        public IQueryable<Lesson> GetListForStudentSchedule(string studentId)
        {
            DateTime todayMidnight = DateTime.Today;
            var studentGroupIds = context.AffiliationAgreements
                .Where(aa => aa.StudentId == studentId)
                .Select(aa => aa.GroupId)
                .ToList(); 

            return context.Lessons
                .Include(l => l.Course)
                .Include(l => l.LessonType)
                .Include(l => l.Group) 
                .Include (l => l.Teacher)
                .Where(lesson => lesson.Beginning > todayMidnight && studentGroupIds.Contains(lesson.GroupId));
        }

        public IQueryable<Lesson> GetPagedLessonsAsync(int page, int pageSize)
        {
            return context.Lessons.Include(l=>l.Course).Include(l=>l.Teacher).Include(l=>l.LessonType).Skip((page - 1) * pageSize).Take(pageSize);
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
