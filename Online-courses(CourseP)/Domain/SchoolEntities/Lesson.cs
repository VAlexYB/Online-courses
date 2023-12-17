using System;
using System.Collections.Generic;

namespace Online_courses_CourseP_.Domain.SchoolEntities;

public partial class Lesson
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public string TeacherId { get; set; }

    public int CourseId { get; set; }

    public int LessonTypeId { get; set; }

    public DateTime? Beginning { get; set; }

    public TimeSpan? Duration { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual LessonType LessonType { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
