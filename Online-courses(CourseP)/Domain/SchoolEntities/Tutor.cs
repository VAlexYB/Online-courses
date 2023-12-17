using Microsoft.AspNetCore.Identity;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Tutor : Employee
{
    [NotMapped]
    public string Password { get; set; }
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
