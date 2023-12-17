using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Skill { get; set; } = null!;

    public int SkillLevelId { get; set; }

    public DateTime? Duration { get; set; }

    public string AdminId { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<ResponsibilityAgreement> ResponsibilityAgreements { get; set; } = new List<ResponsibilityAgreement>();

    public virtual SkillLevel SkillLevel { get; set; } = null!;
}
