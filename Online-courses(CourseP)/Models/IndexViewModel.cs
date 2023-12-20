using MyCompany.Domain;

namespace Online_courses_CourseP_.Models
{
    public class IndexViewModel
    {
        public IEnumerable<SystemUser> Users { get; set; }
        public PageViewModel Page { get; set; }
    }
}
