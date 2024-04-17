using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.ComponentModel.DataAnnotations;

namespace Online_courses_CourseP_.Areas.Tutor.Models
{
    public class LessonViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Начало урока")]
        public DateTime? Beginning { get; set; }

        [Display(Name = "Продолжительность урока")]
        public TimeSpan? Duration { get; set; }

        public int CourseId { get; set; }
        public List<SelectListItem> Courses { get; set; }

        public int GroupId { get; set; }
        public List<SelectListItem> Groups { get; set; } 

        public int LessonTypeId { get; set; }
        public List<SelectListItem> LessonTypes { get; set; }

        public string TeacherId { get; set; }
        public List<SelectListItem> Teachers { get; set; } 
    }
}
