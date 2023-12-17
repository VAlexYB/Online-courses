using Microsoft.AspNetCore.Identity;

namespace Online_courses_CourseP_.Domain.SchoolEntities
{
    public class SystemUser : IdentityUser
    {
        public string? Surname { get; set; }

        public string? Name { get; set; }

        public string? Patronymic { get; set; }
    }
}
