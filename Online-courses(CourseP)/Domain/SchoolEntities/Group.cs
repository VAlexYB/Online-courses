using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Group
{
    public int Id { get; set; }

    public DateTime? Beginning { get; set; }

    public DateTime? Ending { get; set; }

    public int? Amount { get; set; }

    public string TutorId { get; set; }

    public int CourseId { get; set; }

    public virtual ICollection<AffiliationAgreement> AffiliationAgreements { get; set; } = new List<AffiliationAgreement>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Tutor Tutor { get; set; } = null!;
}
