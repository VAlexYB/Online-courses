using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
