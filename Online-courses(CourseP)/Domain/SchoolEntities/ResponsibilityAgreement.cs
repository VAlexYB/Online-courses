using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class ResponsibilityAgreement
{
    public int Id { get; set; }

    public string TeacherId { get; set; }

    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
