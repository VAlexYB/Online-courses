using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class AffiliationAgreement
{
    public  int Id { get; set; }

    public string StudentId { get; set; }

    public int GroupId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
