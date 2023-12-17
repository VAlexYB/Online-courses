using Microsoft.AspNetCore.Identity;

namespace Online_courses_CourseP_.Domain.SchoolEntities
{
    public class Client : SystemUser
    {
        public decimal? Obligation { get; set; }
    }
}
