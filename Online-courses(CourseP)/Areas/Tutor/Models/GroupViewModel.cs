using Microsoft.AspNetCore.Mvc.Rendering;
using Online_courses_CourseP_.Domain.SchoolEntities;
using System.ComponentModel.DataAnnotations;

namespace Online_courses_CourseP_.Areas.Tutor.Models
{
    public class GroupViewModel
    {        
        public int Id { get; set; }

        [Display(Name = "Начало обучения")]
        public DateTime? Beginning { get; set; }

        [Display(Name = "Конец обучения")]
        public DateTime? Ending { get; set; }

        [Display(Name = "Id курса")]
        public int CourseId { get; set; }

        public List<SelectListItem> Courses { get; set; }

        public virtual ICollection<AffiliationAgreement> AffiliationAgreements { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; } 
    }
}
