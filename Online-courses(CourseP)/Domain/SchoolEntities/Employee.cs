using Microsoft.AspNetCore.Identity;

namespace Online_courses_CourseP_.Domain.SchoolEntities
{
    public class Employee : SystemUser
    {
        public DateTime? WorkExperience { get; set; }

        public decimal? Salary { get; set; }
    }
}
