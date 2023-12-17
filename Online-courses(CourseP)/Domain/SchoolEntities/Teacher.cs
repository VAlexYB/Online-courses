using Microsoft.AspNetCore.Identity;
using MyCompany.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Teacher : Employee
{
    [NotMapped]
    public string Password { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<ResponsibilityAgreement> ResponsibilityAgreements { get; set; } = new List<ResponsibilityAgreement>();
}
