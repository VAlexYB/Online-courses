using Microsoft.AspNetCore.Identity;
using MyCompany.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Admin : Employee
{
    [NotMapped]
    public string Password { get; set; }
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
