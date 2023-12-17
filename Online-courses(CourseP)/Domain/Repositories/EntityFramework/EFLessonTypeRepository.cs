using Online_courses_CourseP_.Domain.Repositories.Abstract;
using Online_courses_CourseP_.Domain.SchoolEntities;

namespace Online_courses_CourseP_.Domain.Repositories.EntityFramework
{
    public class EFLessonTypeRepository : ILessonTypeRepository
    {
        private readonly SchoolDbContext context;
        public EFLessonTypeRepository(SchoolDbContext context)
        {
            this.context = context;
        }
        public LessonType GetByID(int id)
        {
            return context.LessonTypes.FirstOrDefault(x => x.Id == id);
        }
    }
}
